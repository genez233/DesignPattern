using AbstractFactory.Interfaces;

namespace AbstractFactory.Products;

public class MacTextBox:ITextBox
{
    public void Display()
    {
        Console.WriteLine("Mac TextBox");
    }
}