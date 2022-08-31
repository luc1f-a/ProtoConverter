namespace ProtoConverter.UnitTests;

public class TestClass
{
    public string StringValue { get; set; }

    public string? NullableStringValue { get; set; }

    public string[] StringArray { get; set; }

    public List<string> StringList { get; set; }


    public SomeClass SomeClassValue { get; set; }

    public SomeClass? NullableSomeClassValue { get; set; }

    public SomeClass[] ArraySomeClass { get; set; }

    public List<SomeClass> ListSomeClass { get; set; }


    public int IntValue { get; set; }

    public int? NullableIntValue { get; set; }

    public int[] IntArray { get; set; }

    public List<int> IntList { get; set; }


    public SomeEnum EnumValue { get; set; }
    
    public SomeEnum? NullableEnumValue { get; set; }

    public SomeEnum[] EnumArray { get; set; }

    public List<SomeEnum> EnumList { get; set; }


    public SomeStruct SomeStructValue { get; set; }

    public SomeStruct? NullableSomeStructValue { get; set; }

    public SomeStruct[] SomeStructArray { get; set; }

    public List<SomeStruct> SomeStructList { get; set; }
}

public class SomeClass
{
    public int Value { get; set; }
        
    public SomeStruct SomeStruct { get; set; }
}

public enum SomeEnum
{
    Unknown = 0,
    Value = 1,
}

public struct SomeStruct
{
    public string Value { get; set; }
}