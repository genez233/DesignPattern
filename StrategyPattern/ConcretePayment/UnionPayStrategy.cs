using StrategyPattern.Interfaces;

namespace StrategyPattern.ConcretePayment;

/// <summary>
/// 具体策略类：银联支付
/// </summary>
public class UnionPayStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"使用银联支付，支付金额: {amount}");
    }
}