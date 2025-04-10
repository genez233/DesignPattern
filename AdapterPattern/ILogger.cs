namespace AdapterPattern;

/// <summary>
/// 日志接口类
/// </summary>
public interface ILogger
{
    void Log(LogLevel level, string message);
}

/// <summary>
/// 日志级别枚举类
/// </summary>
public enum LogLevel
{
    Info,
    Warn,
    Error
}