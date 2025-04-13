using InterpreterPattern.Interfaces;

namespace InterpreterPattern.TerminalExpression;

/// <summary>
/// 实现终结符表达式：数字
/// </summary>
/// <param name="value"></param>
public class NumberExpression(int value) : IExpression
{
    public int Interpret()
    {
        return value;
    }
}