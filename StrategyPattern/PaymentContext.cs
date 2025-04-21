using StrategyPattern.Interfaces;

namespace StrategyPattern;

/// <summary>
/// 上下文环境类
/// </summary>
public class PaymentContext(IPaymentStrategy paymentStrategy)
{
    private IPaymentStrategy _paymentStrategy = paymentStrategy;

    /// <summary>
    /// 动态切换策略
    /// </summary>
    /// <param name="paymentStrategy"></param>
    public void SetStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    /// <summary>
    /// 执行支付
    /// </summary>
    /// <param name="amount"></param>
    public void ExecutePayment(decimal amount)
    {
        _paymentStrategy.ProcessPayment(amount);
    }
}