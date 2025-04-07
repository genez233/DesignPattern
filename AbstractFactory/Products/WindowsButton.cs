using AbstractFactory.Interfaces;

namespace AbstractFactory.Products;

/// <summary>
/// 具体产品：Windows按钮
/// </summary>
public class WindowsButton:IButton
{
    public void Render()
    {
        Console.WriteLine("Windows Button");
    }
}