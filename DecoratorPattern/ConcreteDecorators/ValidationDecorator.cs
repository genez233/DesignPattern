using DecoratorPattern.Components;
using DecoratorPattern.Decorators;
using DecoratorPattern.Models;

namespace DecoratorPattern.ConcreteDecorators;

/// <summary>
/// 具体装饰器：验证装饰器
/// </summary>
/// <param name="orderService"></param>
public class ValidationDecorator(IOrderService orderService) : OrderServiceDecorator(orderService)
{
    public override void ProcessOrder(Order order)
    {
        if (order == null || string.IsNullOrEmpty(order.OrderId))
        {
            throw new ArgumentException("Order is not valid.");
        }

        Console.WriteLine("Validation passed");
        base.ProcessOrder(order);
    }
}