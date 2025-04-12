using ProxyPattern.Subject;

namespace ProxyPattern.Proxy;

// 代理
public class Proxy : ISubject
{
    private RealSubject.RealSubject _realSubject;
    public void Request()
    {
        if (_realSubject == null)
            _realSubject = new RealSubject.RealSubject();
        
        PreRequest();
        _realSubject.Request();
        PostRequest();
    }
    
    private void PreRequest() => Console.WriteLine("Proxy: Preparing request.");
    private void PostRequest() => Console.WriteLine("Proxy: Cleaning up after request.");
}