using StatePattern.Contexts;

namespace StatePattern.Interfaces;

/// <summary>
/// 状态接口
/// </summary>
public interface IOrderState
{
    /// <summary>
    /// 提交支付
    /// </summary>
    /// <param name="context"></param>
    void SubmitPayment(OrderContext context);
    /// <summary>
    /// 发货
    /// </summary>
    /// <param name="context"></param>
    void ShipOrder(OrderContext context);
    /// <summary>
    /// 确认收货
    /// </summary>
    /// <param name="context"></param>
    void ConfirmDelivery(OrderContext context);
}