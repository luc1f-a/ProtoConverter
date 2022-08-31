using System.Text;
using ProtoConverter.Elements;
using Enum = ProtoConverter.Elements.Enum;
using File = ProtoConverter.Elements.File;

namespace ProtoConverter.Visitors;

public class ProtoVisitor : IVisitor
{
    private readonly StringBuilder _stringBuilder = new();
    private readonly AppSettings _settings;

    public ProtoVisitor(AppSettings settings)
    {
        _settings = settings;
    }


    public void Visit(Enum @enum)
    {
        _stringBuilder.Append("enum ");
        _stringBuilder.Append(@enum.Name);
        _stringBuilder.Append("\n{\n");
        foreach (var field in @enum.Fields)
        {
            Visit(field);
        }

        _stringBuilder.Append('}');
    }

    public void Visit(EnumField enumField)
    {
        _stringBuilder.Append("  ");
        _stringBuilder.Append(enumField.Name);
        _stringBuilder.Append(" = ");
        _stringBuilder.Append(enumField.Value);
        _stringBuilder.Append(";\n");
    }

    public string Visit(File file)
    {
        _stringBuilder.Append("syntax = \"proto3\";\n");
        foreach (var import in file.Imports)
        {
            _stringBuilder.Append("\nimport \"");
            _stringBuilder.Append(_settings.Package);
            _stringBuilder.Append('/');
            _stringBuilder.Append(import);
            _stringBuilder.Append(".proto\";");
        }

        _stringBuilder.Append("\noption csharp_namespace = \"");
        _stringBuilder.Append(_settings.Namespace);
        _stringBuilder.Append("\";\n\n");
        _stringBuilder.Append("package ");
        _stringBuilder.Append(_settings.Package);
        _stringBuilder.Append(";\n\n");

        foreach (var message in file.Messages)
        {
            Visit(message);
        }

        foreach (var @enum in file.Enums)
        {
            Visit(@enum);
        }

        try
        {
            return _stringBuilder.ToString();
        }
        finally
        {
            _stringBuilder.Clear();
        }
    }

    public void Visit(Message message)
    {
        _stringBuilder.Append("message ");
        _stringBuilder.Append(message.Name);
        _stringBuilder.Append(" {\n");
        foreach (var field in message.Fields)
        {
            Visit(field);
        }

        _stringBuilder.Append('}');
    }

    public void Visit(MessageField messageField)
    {
        _stringBuilder.Append("  ");
        if (messageField.IsCollection)
        {
            _stringBuilder.Append("repeated ");
        }

        if (messageField.NeedImport)
        {
            _stringBuilder.Append(_settings.Package);
            _stringBuilder.Append('.');
        }

        _stringBuilder.Append(TryCovertTypeToProtoTypeName(messageField.TypeName));
        _stringBuilder.Append(' ');
        _stringBuilder.Append(messageField.Name);
        _stringBuilder.Append(" = ");
        _stringBuilder.Append(messageField.Value);
        _stringBuilder.Append(";\n");
    }

    private static string TryCovertTypeToProtoTypeName(string csharpType) =>
        csharpType switch
        {
            "double" or "Double" or "Decimal" => "double",
            "float" => "float",
            "int" or "Int32" or "Byte" => "int32",
            "long" or "Int64" => "int64",
            "uint" or "UInt32" => "uint32",
            "ulong" or "UInt64" => "uint64",
            "bool" or "Boolean" => "bool",
            "string" or "String" => "string",
            "ByteString" or "byte[]" => "bytes",
            _ => csharpType
        };
}