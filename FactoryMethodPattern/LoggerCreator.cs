namespace FactoryMethodPattern;

/// <summary>
/// 定义日志创建者抽象类
/// </summary>
public abstract class LoggerCreator
{
    public abstract ILogger CreateLogger();

    public void Log(string message)
    {
        ILogger logger = CreateLogger();
        logger.Log(message);
    }
}