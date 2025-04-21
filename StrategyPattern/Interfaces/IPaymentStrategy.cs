namespace StrategyPattern.Interfaces;

/// <summary>
/// 定义抽象策略接口
/// </summary>
public interface IPaymentStrategy
{
    void ProcessPayment(decimal amount);
}