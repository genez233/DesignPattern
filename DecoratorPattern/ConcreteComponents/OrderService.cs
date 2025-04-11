using DecoratorPattern.Components;
using DecoratorPattern.Models;

namespace DecoratorPattern.ConcreteComponents;

/// <summary>
/// 具体实现类：订单处理服务
/// </summary>
public class OrderService : IOrderService
{
    public void ProcessOrder(Order order)
    {
        Console.WriteLine("Processing order...");
    }
}