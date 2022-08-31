namespace ProtoConverter.Elements;

public class Message : IElement
{
    public string Name { get; set; }

    public List<MessageField> Fields { get; set; } = new();
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}