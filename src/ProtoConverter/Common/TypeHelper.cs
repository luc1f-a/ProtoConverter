using System.Collections;

namespace ProtoConverter.Common;

public static class TypeHelper
{
    public static Type GetInternalType(this Type type) =>
        type switch
        {
            _ when type.IsArray => type.GetElementType()!,
            _ when (type.Name != nameof(String) && type.GetInterface(nameof(IEnumerable)) != null) || Nullable.GetUnderlyingType(type) != null => type.GenericTypeArguments[0],
            _ => type
        };

    public static string GetName(this Type type) =>
        type switch
        {
            _ when type.IsArray => type.Name[..^2],
            _ when (type.Name != nameof(String) && type.GetInterface(nameof(IEnumerable)) != null) || Nullable.GetUnderlyingType(type) != null => type.GenericTypeArguments[0].Name,
            _ => type.Name
        };

    public static bool IsCollection(this Type type) =>
        type switch
        {
            _ when type.IsArray => true,
            _ when type.Name != nameof(String) && type.GetInterface(nameof(IEnumerable)) != null => true,
            _ => false
        };
}