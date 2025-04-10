namespace PrototypePattern;

/// <summary>
/// 员工类：深拷贝：手动深拷贝
/// </summary>
public class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public List<string> Skills { get; set; }

    /// <summary>
    /// 克隆 实现浅拷贝
    /// 浅拷贝仅复制对象的值类型字段和引用类型字段的引用（共享同一内存地址）。
    /// </summary>
    /// <returns></returns>
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}