namespace FactoryMethodPattern;

public class DatabaseLoggerCreator:LoggerCreator
{
    public override ILogger CreateLogger()
    {
        return new DatabaseLogger();
    }
}