using StatePattern.Contexts;
using StatePattern.Interfaces;

namespace StatePattern.ConcreteState;

/// <summary>
/// 具体状态类：完成
/// </summary>
public class CompletedState : IOrderState
{
    public void SubmitPayment(OrderContext context)
    {
        throw new InvalidOperationException("订单已完成，无法操作。");
    }

    public void ShipOrder(OrderContext context)
    {
        throw new InvalidOperationException("订单已完成，无法操作。");
    }

    public void ConfirmDelivery(OrderContext context)
    {
        throw new InvalidOperationException("订单已完成，无需重复确认。");
    }
}