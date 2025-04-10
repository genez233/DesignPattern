using System.Text.Json;

namespace PrototypePattern;

/// <summary>
/// 客户类 深拷贝：通过序列化实现通用深拷贝
/// </summary>
public static class ObjectExtension
{
    public static T DeepCopy<T>(this T obj)
    {
        var json = JsonSerializer.Serialize(obj);
        return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException();
    }
}