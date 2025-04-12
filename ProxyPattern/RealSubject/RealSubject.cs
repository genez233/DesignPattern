using ProxyPattern.Subject;

namespace ProxyPattern.RealSubject;

/// <summary>
/// 真实主题
/// </summary>
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject.Request");
    }
}