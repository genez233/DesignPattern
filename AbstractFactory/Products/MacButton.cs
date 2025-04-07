using AbstractFactory.Interfaces;

namespace AbstractFactory.Products;

/// <summary>
/// 具体产品：Mac按钮
/// </summary>
public class MacButton:IButton
{
    public void Render()
    {
        Console.WriteLine("Mac Button");
    }
}