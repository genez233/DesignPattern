using DecoratorPattern.Components;
using DecoratorPattern.Decorators;
using DecoratorPattern.Models;

namespace DecoratorPattern.ConcreteDecorators;

/// <summary>
/// 具体装饰器：日志装饰器
/// </summary>
/// <param name="orderService"></param>
public class LoggerDecorator(IOrderService orderService) : OrderServiceDecorator(orderService)
{
    public override void ProcessOrder(Order order)
    {
        Console.WriteLine("Logging order...");
        base.ProcessOrder(order);
        Console.WriteLine("Order logged.");
    }
}