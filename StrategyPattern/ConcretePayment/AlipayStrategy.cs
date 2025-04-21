using StrategyPattern.Interfaces;

namespace StrategyPattern.ConcretePayment;

/// <summary>
/// 具体策略类：支付宝支付
/// </summary>
public class AlipayStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"使用支付宝支付，支付金额：{amount}");
    }
}