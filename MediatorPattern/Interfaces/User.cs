namespace MediatorPattern.Interfaces;

/// <summary>
/// 同事类接口
/// </summary>
public abstract class User
{
    protected IChatMediator Mediator;
    public string Name { get; set; }
    
    protected User(IChatMediator mediator, string name)
    {
        Mediator = mediator;
        Name = name;
    }
    
    public abstract void Send(string message);
    public abstract void Receive(string message);
}