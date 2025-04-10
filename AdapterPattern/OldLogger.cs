namespace AdapterPattern;

/// <summary>
/// 旧日志组件
/// </summary>
public class OldLogger
{
    public void LogMessage(string message)
    {
        Console.WriteLine($"旧日志组件：{message}");
    }
}