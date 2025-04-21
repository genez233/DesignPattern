using StatePattern.Contexts;
using StatePattern.Interfaces;

namespace StatePattern.ConcreteState;

/// <summary>
/// 具体状态类：待付款
/// </summary>
public class PendingPaymentState : IOrderState
{
    public void SubmitPayment(OrderContext context)
    {
        Console.WriteLine("支付成功，订单状态更新为已支付。");
        context.ChangeState(new PaidState());
    }

    public void ShipOrder(OrderContext context)
    {
        throw new InvalidOperationException("无法发货，订单尚未支付。");
    }

    public void ConfirmDelivery(OrderContext context)
    {
        throw new InvalidOperationException("无法确认收货，订单未发货。");
    }
}