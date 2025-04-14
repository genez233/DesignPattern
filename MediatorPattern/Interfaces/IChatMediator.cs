namespace MediatorPattern.Interfaces;

/// <summary>
/// 中介者接口
/// </summary>
public interface IChatMediator
{
    void SendMessage(string message, User user);
    void RegisterUser(User user);
}