# 适配器（Adapter）
#### 什么是适配器模式？

适配器模式是一种**结构型设计模式**，用于解决两个不兼容接口之间的兼容性问题。它通过将一个类的接口转换成客户端期望的另一个接口，使原本因接口不匹配而无法协同工作的类能够一起工作。

#### 模式类型

1. **类适配器**（通过多重继承实现，C# 不支持，故不常用）。
2. **对象适配器**（通过组合实现，推荐在 .NET 中使用）。

---

### 适配器模式的核心组成

1. **目标接口（Target）**

   客户端期望使用的接口。
2. **适配者类（Adaptee）**

   需要被适配的现有类（旧的或第三方组件）。
3. **适配器类（Adapter）**

   实现目标接口，并在内部调用适配者的功能。

---

### 应用场景

- 集成第三方库或旧系统代码时，接口不兼容。
- 统一多个类的接口以提供一致性。
- 复用现有类但无法修改其源代码。

---

### .NET Core 代码示例

#### 场景描述

假设有一个旧的日志组件 `OldLogger`，它有一个方法 `LogMessage(string message)`，而新的系统要求使用统一的 `ILogger` 接口，其中包含 `Log(LogLevel level, string message)`。我们需要通过适配器让旧日志组件支持新接口。

#### 代码实现

1. **定义目标接口 ****`ILogger`**

```C#
public enum LogLevel
{
    Info,
    Warning,
    Error
}

public interface ILogger
{
    void Log(LogLevel level, string message);
}
```
2. **定义旧的日志组件（Adaptee）**

```C#
public class OldLogger
{
    public void LogMessage(string message)
    {
        Console.WriteLine($"Old Logger: {message}");
    }
}
```
3. **创建适配器类 ****`OldLoggerAdapter`**

```C#
public class OldLoggerAdapter : ILogger
{
    private readonly OldLogger _oldLogger;

    public OldLoggerAdapter(OldLogger oldLogger)
    {
        _oldLogger = oldLogger;
    }

    public void Log(LogLevel level, string message)
    {
        // 将新的日志格式转换为旧组件支持的格式
        var formattedMessage = $"[{level}] {message}";
        _oldLogger.LogMessage(formattedMessage);
    }
}
```
4. **客户端调用**

```C#
class Program
{
    static void Main(string[] args)
    {
        // 使用旧日志组件，但通过适配器符合新接口
        var oldLogger = new OldLogger();
        ILogger logger = new OldLoggerAdapter(oldLogger);
        
        // 调用统一的接口
        logger.Log(LogLevel.Error, "This is an error message.");
    }
}
```

**输出结果：**

```Markdown
Old Logger: [Error] This is an error message.
```

---

### 适配器模式的优势

1. **解耦性**：客户端与适配者解耦，无需修改原有代码。
2. **复用性**：复用现有类，无需重新实现功能。
3. **灵活性**：适配不同接口，提高系统扩展性。

---

### 注意事项

- **避免过度设计**：如果接口兼容，无需使用适配器。
- **依赖注入优化**：在 .NET Core 中可通过依赖注入容器注册适配器，提升可维护性。

```C#
// 在 Startup.cs 或类似配置类中注册
services.AddSingleton<OldLogger>();
services.AddSingleton<ILogger>(provider => 
    new OldLoggerAdapter(provider.GetRequiredService<OldLogger>()));
```

---

通过适配器模式，你可以轻松整合新旧组件或第三方库，让不兼容的接口协同工作，提升代码的可维护性和扩展性。