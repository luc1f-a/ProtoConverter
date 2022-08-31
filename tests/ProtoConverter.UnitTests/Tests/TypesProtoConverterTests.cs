using DeepEqual.Syntax;
using NUnit.Framework;
using ProtoConverter.UnitTests.Extensions;
using File = ProtoConverter.Elements.File;

namespace ProtoConverter.UnitTests.Tests;

[TestFixture]
public class TypesProtoConverterTests
{
    private Converters.ProtoConverter _protoConverter;

    [SetUp]
    public void SetUp()
    {
        _protoConverter = new Converters.ProtoConverter();
    }

    [Test]
    public void SomeClass()
    {
        var type = typeof(SomeClass);

        var file = _protoConverter.Convert(type);

        Assert.AreEqual(2, file.Count);

        Assert.AreEqual("SomeClass", file[0].Name);
        Assert.AreEqual("SomeClass", file[0].Messages[0].Name);

        Assert.AreEqual("Value", file[0].Messages[0].Fields[0].Name);
        Assert.AreEqual("Int32", file[0].Messages[0].Fields[0].TypeName);

        Assert.AreEqual("SomeStruct", file[0].Messages[0].Fields[1].Name);
        Assert.AreEqual("SomeStruct", file[0].Messages[0].Fields[1].TypeName);

        Assert.AreEqual("SomeStruct", file[0].Imports[0]);
    }

    [Test]
    public void TestClass()
    {
        var type = typeof(TestClass);
        var expected = GenerateExpectedData();

        var file = _protoConverter.Convert(type);

        file.ShouldDeepEqual(expected);
    }

    [Test]
    public void Enum()
    {
        var type = typeof(SomeEnum);

        var file = _protoConverter.Convert(type);

        Assert.NotNull(file);
        Assert.AreEqual(1, file[0].Enums.Count);
        Assert.AreEqual("SomeEnum", file[0].Enums[0].Name);

        Assert.AreEqual("Unknown", file[0].Enums[0].Fields[0].Name);
        Assert.AreEqual(0, file[0].Enums[0].Fields[0].Value);

        Assert.AreEqual("Value", file[0].Enums[0].Fields[1].Name);
        Assert.AreEqual(1, file[0].Enums[0].Fields[1].Value);
    }

    private List<File> GenerateExpectedData()
    {
        var expected1 = ElementsExtensions.Create("TestClass");
        expected1
            .AddImport("SomeClass")
            .AddImport("SomeEnum")
            .AddImport("SomeStruct")
            .AddMessage("TestClass")
            .AddMessageField("StringValue", "String", 1, false, false)
            .AddMessageField("NullableStringValue", "String", 2, false, false)
            .AddMessageField("StringArray", "String", 3, true, false)
            .AddMessageField("StringList", "String", 4, true, false)
            .AddMessageField("SomeClassValue", "SomeClass", 5, false, true)
            .AddMessageField("NullableSomeClassValue", "SomeClass", 6, false, true)
            .AddMessageField("ArraySomeClass", "SomeClass", 7, true, true)
            .AddMessageField("ListSomeClass", "SomeClass", 8, true, true)
            .AddMessageField("IntValue", "Int32", 9, false, false)
            .AddMessageField("NullableIntValue", "Int32", 10, false, false)
            .AddMessageField("IntArray", "Int32", 11, true, false)
            .AddMessageField("IntList", "Int32", 12, true, false)
            .AddMessageField("EnumValue", "SomeEnum", 13, false, true)
            .AddMessageField("NullableEnumValue", "SomeEnum", 14, false, true)
            .AddMessageField("EnumArray", "SomeEnum", 15, true, true)
            .AddMessageField("EnumList", "SomeEnum", 16, true, true)
            .AddMessageField("SomeStructValue", "SomeStruct", 17, false, true)
            .AddMessageField("NullableSomeStructValue", "SomeStruct", 18, false, true)
            .AddMessageField("SomeStructArray", "SomeStruct", 19, true, true)
            .AddMessageField("SomeStructList", "SomeStruct", 20, true, true);

        var expected2 = ElementsExtensions.Create("SomeClass");
        expected2
            .AddImport("SomeStruct")
            .AddMessage("SomeClass")
            .AddMessageField("Value", "Int32", 1, false, false)
            .AddMessageField("SomeStruct", "SomeStruct", 2, false, true);
        
        var expected3 = ElementsExtensions.Create("SomeStruct");
        expected3
            .AddMessage("SomeStruct")
            .AddMessageField("Value", "String", 1, false, false);
        
        var expected4 = ElementsExtensions.Create("SomeEnum");
        expected4
            .AddEnum("SomeEnum")
            .AddEnumField("Unknown", 0)
            .AddEnumField("Value", 1);

        return new List<File>()
        {
            expected1, expected2, expected3, expected4
        };
    }
}