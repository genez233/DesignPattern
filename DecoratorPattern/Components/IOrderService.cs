using DecoratorPattern.Models;

namespace DecoratorPattern.Components;

// 订单处理组件接口
public interface IOrderService
{
    void ProcessOrder(Order order);
}