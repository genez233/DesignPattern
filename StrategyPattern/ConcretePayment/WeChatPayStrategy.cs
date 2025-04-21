using StrategyPattern.Interfaces;

namespace StrategyPattern.ConcretePayment;

/// <summary>
/// 具体策略类：微信支付
/// </summary>
public class WeChatPayStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"使用微信支付，支付金额：{amount}");
    }
}