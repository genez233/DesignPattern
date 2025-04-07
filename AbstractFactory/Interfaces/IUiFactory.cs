namespace AbstractFactory.Interfaces;

/// <summary>
/// 抽象工厂接口
/// </summary>
public interface IUiFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}