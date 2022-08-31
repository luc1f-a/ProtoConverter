using ProtoConverter.Elements;
using Enum = ProtoConverter.Elements.Enum;
using File = ProtoConverter.Elements.File;


namespace ProtoConverter;

public interface IVisitor
{
    void Visit(Enum @enum);
    void Visit(EnumField enumField);
    string Visit(File file);
    void Visit(Message message);
    void Visit(MessageField messageField);
}