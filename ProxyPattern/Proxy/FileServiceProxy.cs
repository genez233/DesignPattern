using ProxyPattern.RealSubject;
using ProxyPattern.Subject;

namespace ProxyPattern.Proxy;

/// <summary>
/// 实现保护代理：文件服务代理
/// </summary>
public class FileServiceProxy(string userRole) : IFileViewer
{
    private readonly FileService _fileService = new();

    public void ViewFile(string fileName)
    {
        if (CheckAccess())
        {
            _fileService.ViewFile(fileName);
        }
        else
        {
            Console.WriteLine("Access denied.");
        }
    }
    
    private bool CheckAccess() => userRole == "admin";
}