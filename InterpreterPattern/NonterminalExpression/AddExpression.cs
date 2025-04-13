using InterpreterPattern.Interfaces;

namespace InterpreterPattern.NonterminalExpression;

/// <summary>
/// 实现非终结符表达式：加法
/// </summary>
public class AddExpression(IExpression left, IExpression right) : IExpression
{
    public int Interpret()
    {
        return left.Interpret() + right.Interpret();
    }
}