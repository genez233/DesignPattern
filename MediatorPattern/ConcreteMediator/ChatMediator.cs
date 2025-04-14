using MediatorPattern.Interfaces;

namespace MediatorPattern.ConcreteMediator;

/// <summary>
/// 实现具体中介者类
/// </summary>
public class ChatMediator : IChatMediator
{
    private readonly List<User> _users = new();
    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.Receive($"[{sender.Name}]: {message}");
            }
        }
    }

    public void RegisterUser(User user)
    {
        _users.Add(user);
    }
}