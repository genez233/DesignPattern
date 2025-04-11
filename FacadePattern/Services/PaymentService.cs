namespace FacadePattern.Services;

/// <summary>
/// 支付服务
/// </summary>
public class PaymentService
{
    public bool ProcessPayment(string userId, decimal amount)
    {
        Console.WriteLine($"Processing payment for user: {userId}, amount: {amount}");
        // 模拟支付成功
        return true;
    }
}