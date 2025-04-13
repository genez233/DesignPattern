namespace ProxyPattern.Subject;

/// <summary>
/// 文件服务接口：文件查看器
/// </summary>
public interface IFileViewer
{
    void ViewFile(string fileName);
}