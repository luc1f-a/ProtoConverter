using NUnit.Framework;
using ProtoConverter.Visitors;

namespace ProtoConverter.UnitTests.Tests;

[TestFixture]
public class ProtoVisitorTests
{
    private Converters.ProtoConverter _protoConverter;
    private ProtoVisitor _protoVisitor;

    [SetUp]
    public void SetUp()
    {
        var settings = new AppSettings()
        {
            Namespace = "ProtoConverter.UnitTests",
            Package = "ProtoConverter"
        };

        _protoVisitor = new ProtoVisitor(settings);
        _protoConverter = new Converters.ProtoConverter();
    }

    [Test]
    public void TestClass()
    {
        var type = typeof(TestClass);
        var expected = GetExpectedTestClassString();
        var files = _protoConverter.Convert(type);

        var result = _protoVisitor.Visit(files[0]);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Enum()
    {
        var type = typeof(SomeEnum);
        var expected = GetExpectedEnumString();
        var files = _protoConverter.Convert(type);

        var result =_protoVisitor.Visit(files[0]);

        Assert.AreEqual(expected, result);
    }

    private string GetExpectedEnumString()
    {
        return @"syntax = ""proto3"";

option csharp_namespace = ""ProtoConverter.UnitTests"";

package ProtoConverter;

enum SomeEnum
{
  Unknown = 0;
  Value = 1;
}".Replace("\r\n", "\n");
    }

    private string GetExpectedTestClassString()
    {
        return @"syntax = ""proto3"";

import ""ProtoConverter.SomeClass"";
import ""ProtoConverter.SomeEnum"";
import ""ProtoConverter.SomeStruct"";
option csharp_namespace = ""ProtoConverter.UnitTests"";

package ProtoConverter;

message TestClass {
  string StringValue = 1;
  string NullableStringValue = 2;
  repeated string StringArray = 3;
  repeated string StringList = 4;
  ProtoConverter.SomeClass SomeClassValue = 5;
  ProtoConverter.SomeClass NullableSomeClassValue = 6;
  repeated ProtoConverter.SomeClass ArraySomeClass = 7;
  repeated ProtoConverter.SomeClass ListSomeClass = 8;
  int32 IntValue = 9;
  int32 NullableIntValue = 10;
  repeated int32 IntArray = 11;
  repeated int32 IntList = 12;
  ProtoConverter.SomeEnum EnumValue = 13;
  ProtoConverter.SomeEnum NullableEnumValue = 14;
  repeated ProtoConverter.SomeEnum EnumArray = 15;
  repeated ProtoConverter.SomeEnum EnumList = 16;
  ProtoConverter.SomeStruct SomeStructValue = 17;
  ProtoConverter.SomeStruct NullableSomeStructValue = 18;
  repeated ProtoConverter.SomeStruct SomeStructArray = 19;
  repeated ProtoConverter.SomeStruct SomeStructList = 20;
}".Replace("\r\n", "\n");
    }
}