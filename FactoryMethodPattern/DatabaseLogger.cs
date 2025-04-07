namespace FactoryMethodPattern;

/// <summary>
/// 具体日志 数据库记录
/// </summary>
public class DatabaseLogger:ILogger 
{
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] DatabaseLogger {message}");
    }
}