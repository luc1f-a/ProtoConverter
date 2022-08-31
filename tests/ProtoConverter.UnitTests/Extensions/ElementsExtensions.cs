using ProtoConverter.Elements;
using Enum = ProtoConverter.Elements.Enum;
using File = ProtoConverter.Elements.File;

namespace ProtoConverter.UnitTests.Extensions;

public static class ElementsExtensions
{
    public static File Create(string name)
    {
        return new File
        {
            Name = name
        };
    }

    public static File AddImport(this File file, string import)
    {
        file.Imports.Add(import);
        return file;
    }
    
    public static Message AddMessage(this File file, string name)
    {
        var message = new Message
        {
            Name = name,
        };
        file.Messages.Add(message);
        return message;
    }    
        
    public static Message AddMessageField(this Message message, string name, string typeName, int value, bool isRepeated, bool needImport)
    {
        var messageField = new MessageField()
        {
            Name = name,
            Value = value,
            IsCollection = isRepeated,
            NeedImport = needImport,
            TypeName =typeName, 
        };
        message.Fields.Add(messageField);
        return message;
    }    
    
    public static Enum AddEnum(this File file, string name)
    {
        var @enum = new Enum
        {
            Name = name
        };
        file.Enums.Add(@enum);
        return @enum;
    }    
    
    public static Enum AddEnumField(this Enum @enum, string name, int value)
    {
        var message = new EnumField()
        {
            Name = name,
            Value = value,
        };
        @enum.Fields.Add(message);
        return @enum;
    }
}