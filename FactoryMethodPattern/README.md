# 工厂方法模式

工厂方法模式是一种创建型设计模式，通过将对象的创建延迟到子类来实现解耦，是面向对象设计中"开闭原则"的经典实践。以下从多线程、高并发设计到应用场景进行详细解析：

---

### 一、核心概念解析

**定义**：定义一个创建对象的接口，但让实现这个接口的类来决定实例化哪个类。工厂方法让类的实例化延迟到子类。

**UML核心元素**：

- `Product`：产品接口
- `ConcreteProduct`：具体产品实现
- `Creator`：抽象工厂（声明工厂方法）
- `ConcreteCreator`：具体工厂（实现工厂方法）

```C#
// 产品接口
interface ILogger {
    void Log(String message);
}

// 具体产品
public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] FileLogger {message}");
    }
}
public class DatabaseLogger:ILogger 
{
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] DatabaseLogger {message}");
    }
}

// 抽象工厂
public abstract class LoggerCreator
{
    public abstract ILogger CreateLogger();

    public void Log(string message)
    {
        ILogger logger = CreateLogger();
        logger.Log(message);
    }
}
// 具体工厂
public class FileLoggerCreator : LoggerCreator
{
    public override ILogger CreateLogger()
    {
        return new FileLogger();
    }
}
public class DatabaseLoggerCreator:LoggerCreator
{
    public override ILogger CreateLogger()
    {
        return new DatabaseLogger();
    }
}
```

---

### 二、典型应用场景

1. **框架扩展点设计**
- Spring Framework的BeanFactory
- SLF4J的LoggerFactory
1. **跨平台兼容**

```C#
// 跨平台UI组件创建
interface GUIFactory {
    Button createButton();
}

class WinFactory : GUIFactory { /*...*/ }
class MacFactory : GUIFactory { /*...*/ }
```
2. **动态策略选择**

```C#
class PaymentProcessor {
    public static PaymentFactory getFactory(PaymentType type) {
        switch(type) {
            case ALIPAY: return new AlipayFactory();
            case WECHAT: return new WechatPayFactory();
            default: throw new IllegalArgumentException();
        }
    }
}
```
3. **复杂对象创建**
- 数据库连接创建
- 游戏角色生成
- 文档解析器创建

---

### 三、设计注意事项

1. **层次控制**：避免过度抽象导致工厂类爆炸
2. **生命周期管理**：结合单例模式或对象池管理对象实例
3. **依赖注入**：推荐使用IoC容器（如Autofac）管理工厂
4. **性能权衡**：高并发场景需在灵活性和性能之间找到平衡点

---

### 六、模式对比

|模式|特点|适用场景|
|-|-|-|
|简单工厂|集中式创建，违反开闭原则|产品类型较少|
|工厂方法|分散到子类，符合OCP|产品类型较多|
|抽象工厂|产品族创建|系列相关产品|


---

通过合理应用工厂方法模式，可以在保持系统扩展性的同时有效应对多线程和高并发挑战。实际开发中建议结合具体业务场景，配合其他模式（如代理模式、装饰器模式）形成完整的解决方案。

