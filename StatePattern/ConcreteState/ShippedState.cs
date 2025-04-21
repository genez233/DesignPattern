using StatePattern.Contexts;
using StatePattern.Interfaces;

namespace StatePattern.ConcreteState;

/// <summary>
/// 具体状态类：已发货
/// </summary>
public class ShippedState : IOrderState
{
    public void SubmitPayment(OrderContext context)
    {
        throw new InvalidOperationException("订单已完成，无需重复支付。");
    }

    public void ShipOrder(OrderContext context)
    {
        throw new InvalidOperationException("订单已发货，请勿重复操作。");
    }

    public void ConfirmDelivery(OrderContext context)
    {
        Console.WriteLine("订单已确认收货，订单状态更新为已完成。");
        context.ChangeState(new CompletedState());
    }
}