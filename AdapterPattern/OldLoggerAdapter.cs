namespace AdapterPattern;

/// <summary>
/// 适配器类：适配旧日志类
/// </summary>
public class OldLoggerAdapter(OldLogger oldLogger) : ILogger
{
    private readonly OldLogger _oldLogger = oldLogger;
    public void Log(LogLevel level, string message)
    {
        var formattedMessage = $"[{level}] {message}";
        _oldLogger.LogMessage(formattedMessage);
    }
}