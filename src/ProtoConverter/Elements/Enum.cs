namespace ProtoConverter.Elements;
public class Enum: IElement
{
    public string Name { get; set; }

    public List<EnumField> Fields { get; set; } = new();
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}