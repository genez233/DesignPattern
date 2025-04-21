using System;

namespace FactoryMethodPattern;

/// <summary>
/// 具体日志 文件记录
/// </summary>
public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] FileLogger {message}");
    }
}