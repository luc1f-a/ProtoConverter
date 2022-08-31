using System.Collections;
using System.Reflection;
using ProtoConverter.Common;
using ProtoConverter.Elements;
using Serilog;
using Enum = ProtoConverter.Elements.Enum;
using File = ProtoConverter.Elements.File;

namespace ProtoConverter.Converters;

public class ProtoConverter
{
    private List<Type> _processedTypes = new();

    public List<File> Convert(Type type)
    {
        _processedTypes.Add(type);
        var file = new File { Name = type.Name };
        var files = new List<File> { file };

        if (type.IsEnum)
        {
            var @enum = new Enum
            {
                Name = type.Name
            };

            Type enumUnderlyingType = System.Enum.GetUnderlyingType(type);
            Array enumValues = System.Enum.GetValues(type);

            for (int i = 0; i < enumValues.Length; i++)
            {
                object value = enumValues.GetValue(i);
                object underlyingValue = System.Convert.ChangeType(value, enumUnderlyingType);

                @enum.Fields.Add(new EnumField
                {
                    Name = value.ToString(),
                    Value = System.Convert.ToInt32(underlyingValue)
                });
            }

            file.Enums.Add(@enum);
        }
        else if ((type.IsClass || type.IsValueType) && type.GetProperties().Length != 0)
        {
            var message = new Message
            {
                Name = type.Name
            };

            file.Messages.Add(message);
            Log.Debug("Processed class: {0}", type.Name);
            foreach (var propertyInfo in type.GetProperties())
            {
                var internalPropertyType = propertyInfo.PropertyType.GetInternalType();
                var messageField = new MessageField
                {
                    Name = propertyInfo.Name,
                    TypeName = propertyInfo.PropertyType.GetName(),
                    IsCollection = propertyInfo.PropertyType.IsCollection(),
                    NeedImport = !internalPropertyType.Module.ScopeName.StartsWith("System"),
                    Value = message.Fields.Count + 1,
                };
                message.Fields.Add(messageField);

                Log.Debug("    Processed property: {0} {1}", messageField.TypeName, messageField.Name);

                if (messageField.NeedImport)
                {
                    if (!file.Imports.Contains(messageField.TypeName))
                    {
                        file.Imports.Add(messageField.TypeName);
                    }

                    if (!_processedTypes.Exists(x => x.Name == messageField.TypeName))
                    {
                        files.AddRange(Convert(internalPropertyType));
                    }
                }
            }
        }

        return files;
    }
}