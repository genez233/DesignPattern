using AbstractFactory.Interfaces;

namespace AbstractFactory.Products;

public class WindowsTextBox:ITextBox
{
    public void Display()
    {
        Console.WriteLine("Windows TextBox");
    }
}