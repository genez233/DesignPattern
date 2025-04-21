using StatePattern.ConcreteState;
using StatePattern.Interfaces;

namespace StatePattern.Contexts;

/// <summary>
/// 定义订单上下文
/// </summary>
public class OrderContext
{
    /// <summary>
    /// 当前状态
    /// </summary>
    private IOrderState _currState;
    
    public OrderContext() => _currState = new PendingPaymentState();
    
    public void ChangeState(IOrderState newState) => _currState = newState;
    
    public void SubmitPayment() => _currState.SubmitPayment(this);
    public void ShipOrder() => _currState.ShipOrder(this);
    public void ConfirmDelivery() => _currState.ConfirmDelivery(this);
}