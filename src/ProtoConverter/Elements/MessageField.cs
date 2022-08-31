namespace ProtoConverter.Elements;

public class MessageField : IElement
{
    public string TypeName { get; set; }

    public string Name { get; set; }

    public int Value { get; set; }

    public bool IsCollection { get; set; }
    
    public bool NeedImport { get; set; }

    public void Accept(IVisitor visitor) => visitor.Visit(this);
}