namespace ProtoConverter.Elements;

public class File : IElement
{
    public string Name { get; set; }
    public List<string> Imports { get; set; } = new();

    public List<Message> Messages { get; set; } = new();

    public List<Enum> Enums { get; set; } = new();

    public void Accept(IVisitor visitor) => visitor.Visit(this);
}