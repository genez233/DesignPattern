using AbstractFactory.Interfaces;
using AbstractFactory.Products;

namespace AbstractFactory;

/// <summary>
/// 具体工厂：Windows工厂
/// </summary>
public class WindowsFactory : IUiFactory
{
    public IButton CreateButton() => new WindowsButton();

    public ITextBox CreateTextBox() => new WindowsTextBox();
}