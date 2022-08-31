namespace ProtoConverter.Elements;

public class EnumField : IElement
{
    public string Name { get; set; }

    public int Value { get; set; }
    
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}