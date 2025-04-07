using AbstractFactory.Interfaces;
using AbstractFactory.Products;

namespace AbstractFactory;

/// <summary>
/// 具体工厂：Mac工厂
/// </summary>
public class MacFactory : IUiFactory
{
    public IButton CreateButton() => new MacButton();

    public ITextBox CreateTextBox() => new MacTextBox();
}