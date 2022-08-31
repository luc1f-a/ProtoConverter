namespace ProtoConverter;

public interface IElement
{
    void Accept(IVisitor visitor);
}