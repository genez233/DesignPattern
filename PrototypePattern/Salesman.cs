namespace PrototypePattern;

/// <summary>
/// 深拷贝：手动拷贝
/// </summary>
public class Salesman : ICloneable
{
    public string Name { get; set; }
    public List<string> Products { get; set; }
    public object Clone()
    {
        var clone = (Salesman)this.MemberwiseClone();
        clone.Products = new List<string>(this.Products);
        return clone;
    }
}