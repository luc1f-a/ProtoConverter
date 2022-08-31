using NUnit.Framework;
using ProtoConverter.Common;

namespace ProtoConverter.UnitTests.Tests.TypeHelperTests;

[TestFixture]
public partial class TypeHelperTests
{
    [Test]
    public void GetName_StringType()
    {
        var propertyType = typeof(TestClass).GetProperties()[0].PropertyType;

        var result = propertyType.GetName();

        Assert.AreEqual("String", result);
    }

    [Test]
    public void GetName_NullableStringType()
    {
        var propertyType = typeof(TestClass).GetProperties()[1].PropertyType;

        var result = propertyType.GetName();

        Assert.AreEqual("String", result);
    }

    [Test]
    public void GetName_ArrayString()
    {
        var propertyType = typeof(TestClass).GetProperties()[2].PropertyType;

        var result = propertyType.GetName();

        Assert.AreEqual("String", result);
    }

    [Test]
    public void GetName_ListString()
    {
        var propertyType = typeof(TestClass).GetProperties()[3].PropertyType;

        var result = propertyType.GetName();

        Assert.AreEqual("String", result);
    }
    
    [Test]
    public void GetName_SomeClassValue()
    {
        var propertyType = typeof(TestClass).GetProperties()[4].PropertyType;

        var result = propertyType.GetName();

        Assert.AreEqual("SomeClass", result);
    }
}