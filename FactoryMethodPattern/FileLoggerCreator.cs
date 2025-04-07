namespace FactoryMethodPattern;

/// <summary>
/// 具体创建者类：文件日志
/// </summary>
public class FileLoggerCreator : LoggerCreator
{
    public override ILogger CreateLogger()
    {
        return new FileLogger();
    }
}