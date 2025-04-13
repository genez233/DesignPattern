using ProxyPattern.Subject;

namespace ProxyPattern.RealSubject;

/// <summary>
/// 真实文件服务：实现文件服务接口
/// </summary>
public class FileService : IFileViewer
{
    public void ViewFile(string fileName)
    {
        Console.WriteLine($"正在查看文件：{fileName}");
    }
}