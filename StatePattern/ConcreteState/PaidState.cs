using StatePattern.Contexts;
using StatePattern.Interfaces;

namespace StatePattern.ConcreteState;

/// <summary>
/// 具体状态类：已支付
/// </summary>
public class PaidState : IOrderState
{
    public void SubmitPayment(OrderContext context)
    {
        throw new InvalidOperationException("订单已支付，无需重复支付。");
    }

    public void ShipOrder(OrderContext context)
    {
        Console.WriteLine("订单已发货，状态更新为已发货。");
        context.ChangeState(new ShippedState());
    }

    public void ConfirmDelivery(OrderContext context)
    {
        throw new InvalidOperationException("订单未发货，无法确认收货。");
    }
}