using FacadePattern.Services;

namespace FacadePattern.Facades;

/// <summary>
/// 外观类：订单处理
/// </summary>
public class OrderFacade(InventoryService inventoryService, PaymentService paymentService, EmailService emailService)
{
    /// <summary>
    /// 统一处理订单接口
    /// </summary>
    /// <param name="productId">商品编号</param>
    /// <param name="quantity">商品数量</param>
    /// <param name="userId">用户编号</param>
    /// <param name="amount">订单金额</param>
    /// <param name="email">邮件地址</param>
    /// <returns></returns>
    public bool PlaceOrder(string productId, int quantity, string userId, decimal amount, string email)
    {
        if (!inventoryService.CheckStock(productId, quantity))
        {
            Console.WriteLine("库存不足");
            return false;
        }

        if (!paymentService.ProcessPayment(userId, amount))
        {
            Console.WriteLine("支付失败");
            return false;
        }
        
        emailService.SendConfirmation(email, "订单已提交");
        return true;
    }
}