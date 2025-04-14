using MediatorPattern.Interfaces;

namespace MediatorPattern.ConcreteMediator;

/// <summary>
/// 具体同事类
/// </summary>
public class ChatUser : User
{
    public ChatUser(IChatMediator mediator, string name) : base(mediator, name)
    {
        mediator.RegisterUser(this);
    }
    
    
    public override void Send(string message)
    {
        Console.WriteLine($"{Name} 发送消息：{message}");
        Mediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name} 接收到消息：{message}");
    }
}