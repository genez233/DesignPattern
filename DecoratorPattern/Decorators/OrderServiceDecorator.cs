using DecoratorPattern.Components;
using DecoratorPattern.Models;

namespace DecoratorPattern.Decorators;

/// <summary>
/// 装饰器基类
/// </summary>
/// <param name="orderService"></param>
public abstract class OrderServiceDecorator(IOrderService orderService) : IOrderService
{
    public virtual void ProcessOrder(Order order)
    {
        orderService.ProcessOrder(order);
    }
}