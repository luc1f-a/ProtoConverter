using NUnit.Framework;
using ProtoConverter.Common;

namespace ProtoConverter.UnitTests.Tests.TypeHelperTests;

[TestFixture]
public partial class TypeHelperTests
{
    [Test]
    public void GetInternalType_StringType()
    {
        var propertyType = typeof(TestClass).GetProperties()[0].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(string), result);
    }

    [Test]
    public void GetInternalType_NullableStringType()
    {
        var propertyType = typeof(TestClass).GetProperties()[1].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(string), result);
    }

    [Test]
    public void GetInternalType_ArrayString()
    {
        var propertyType = typeof(TestClass).GetProperties()[2].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(string), result);
    }

    [Test]
    public void GetInternalType_ListString()
    {
        var propertyType = typeof(TestClass).GetProperties()[3].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(string), result);
    }


    [Test]
    public void GetInternalType_SomeClass()
    {
        var propertyType = typeof(TestClass).GetProperties()[4].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeClass), result);
    }

    [Test]
    public void GetInternalType_NullableSomeClass()
    {
        var propertyType = typeof(TestClass).GetProperties()[5].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeClass), result);
    }

    [Test]
    public void GetInternalType_ArraySomeClass()
    {
        var propertyType = typeof(TestClass).GetProperties()[6].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeClass), result);
    }

    [Test]
    public void GetInternalType_ListSomeClass()
    {
        var propertyType = typeof(TestClass).GetProperties()[7].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeClass), result);
    }


    [Test]
    public void GetInternalType_IntType()
    {
        var propertyType = typeof(TestClass).GetProperties()[8].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(int), result);
    }

    [Test]
    public void GetInternalType_NullableInt()
    {
        var propertyType = typeof(TestClass).GetProperties()[9].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(int), result);
    }

    [Test]
    public void GetInternalType_ArrayInt()
    {
        var propertyType = typeof(TestClass).GetProperties()[10].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(int), result);
    }

    [Test]
    public void GetInternalType_ListInt()
    {
        var propertyType = typeof(TestClass).GetProperties()[11].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(int), result);
    }


    [Test]
    public void GetInternalType_SomeEnum()
    {
        var propertyType = typeof(TestClass).GetProperties()[12].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeEnum), result);
    }

    [Test]
    public void GetInternalType_NullableSomeEnum()
    {
        var propertyType = typeof(TestClass).GetProperties()[13].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeEnum), result);
    }

    [Test]
    public void GetInternalType_ArraySomeEnum()
    {
        var propertyType = typeof(TestClass).GetProperties()[14].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeEnum), result);
    }

    [Test]
    public void GetInternalType_ListSomeEnum()
    {
        var propertyType = typeof(TestClass).GetProperties()[15].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeEnum), result);
    }

    [Test]
    public void GetInternalType_SomeStruct()
    {
        var propertyType = typeof(TestClass).GetProperties()[16].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeStruct), result);
    }

    [Test]
    public void GetInternalType_NullableSomeStruct()
    {
        var propertyType = typeof(TestClass).GetProperties()[17].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeStruct), result);
    }

    [Test]
    public void GetInternalType_ArraySomeStruct()
    {
        var propertyType = typeof(TestClass).GetProperties()[18].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeStruct), result);
    }

    [Test]
    public void GetInternalType_ListSomeStruct()
    {
        var propertyType = typeof(TestClass).GetProperties()[19].PropertyType;

        var result = propertyType.GetInternalType();

        Assert.AreEqual(typeof(SomeStruct), result);
    }
}