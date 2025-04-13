using InterpreterPattern.Interfaces;

namespace InterpreterPattern.NonterminalExpression;

/// <summary>
/// 非终结符表达式：减法
/// </summary>
/// <param name="left"></param>
/// <param name="right"></param>
public class SubtractExpression(IExpression left, IExpression right) : IExpression
{
    public int Interpret()
    {
        return left.Interpret() - right.Interpret();
    }
}