# 抽象工厂模式

抽象工厂模式是一种创建型设计模式，用于创建相关或依赖对象的家族，而无需指定具体类。以下从基础结构、多线程优化和高并发设计三个层次进行详细说明：

---

### 一、抽象工厂模式基础结构

```C#
// 抽象产品接口
public interface IButton { void Render(); }
public interface ITextBox { void Display(); }

// 具体产品
public class WindowsButton : IButton { public void Render() => Console.WriteLine("Windows按钮"); }
public class MacButton : IButton { public void Render() => Console.WriteLine("Mac按钮"); }

public class WindowsTextBox : ITextBox { public void Display() => Console.WriteLine("Windows文本框"); }
public class MacTextBox : ITextBox { public void Display() => Console.WriteLine("Mac文本框"); }

// 抽象工厂接口
public interface IUIFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}

// 具体工厂
public class WindowsUIFactory : IUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ITextBox CreateTextBox() => new WindowsTextBox();
}

public class MacUIFactory : IUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ITextBox CreateTextBox() => new MacTextBox();
}
```

---

### 二、多线程环境优化

#### 1. 线程安全的工厂单例

```C#
public sealed class WindowsUIFactory : IUIFactory
{
    private static readonly Lazy<WindowsUIFactory> _instance = 
        new Lazy<WindowsUIFactory>(() => new WindowsUIFactory(), LazyThreadSafetyMode.ExecutionAndPublication);
    
    public static IUIFactory Instance => _instance.Value;
    
    private WindowsUIFactory() { }
    
    public IButton CreateButton() => new WindowsButton();
    public ITextBox CreateTextBox() => new WindowsTextBox();
}
```

#### 2. 双重检查锁定对象池

```C#
public class ObjectPool<T> where T : new()
{
    private readonly ConcurrentBag<T> _pool = new ConcurrentBag<T>();
    private int _counter = 0;
    private readonly int _maxSize;

    public ObjectPool(int maxSize) => _maxSize = maxSize;

    public T GetObject()
    {
        if (_pool.TryTake(out T item))
            return item;
        
        if (Interlocked.Increment(ref _counter) <= _maxSize)
            return new T();
        
        Interlocked.Decrement(ref _counter);
        lock (_pool)
        {
            while (!_pool.TryTake(out item)) 
                Monitor.Wait(_pool);
            return item;
        }
    }

    public void ReturnObject(T item)
    {
        _pool.Add(item);
        lock (_pool) { Monitor.Pulse(_pool); }
    }
}
```

---

### 三、高并发场景设计策略

#### 1. 无状态工厂 + 延迟初始化

```C#
public class ThreadSafeUIFactory : IUIFactory
{
    private readonly Lazy<IButton> _button;
    private readonly Lazy<ITextBox> _textBox;

    public ThreadSafeUIFactory(Func<IButton> buttonFactory, Func<ITextBox> textBoxFactory)
    {
        _button = new Lazy<IButton>(buttonFactory, LazyThreadSafetyMode.ExecutionAndPublication);
        _textBox = new Lazy<ITextBox>(textBoxFactory, LazyThreadSafetyMode.ExecutionAndPublication);
    }

    public IButton CreateButton() => _button.Value;
    public ITextBox CreateTextBox() => _textBox.Value;
}
```

#### 2. 异步工厂模式

```C#
public interface IAsyncUIFactory
{
    Task<IButton> CreateButtonAsync();
    Task<ITextBox> CreateTextBoxAsync();
}

public class CloudUIFactory : IAsyncUIFactory
{
    public async Task<IButton> CreateButtonAsync()
    {
        await Task.Delay(100); // 模拟网络请求
        return new CloudButton();
    }
}
```

#### 3. 并发缓存优化

```C#
public class CachedUIFactory : IUIFactory
{
    private readonly ConcurrentDictionary<Type, object> _cache = new ConcurrentDictionary<Type, object>();
    private readonly IUIFactory _innerFactory;

    public CachedUIFactory(IUIFactory factory) => _innerFactory = factory;

    public IButton CreateButton() => 
        (IButton)_cache.GetOrAdd(typeof(IButton), _ => _innerFactory.CreateButton());

    public ITextBox CreateTextBox() => 
        (ITextBox)_cache.GetOrAdd(typeof(ITextBox), _ => _innerFactory.CreateTextBox());
}
```

---

### 四、综合设计原则

1. **无状态设计**：工厂类尽量保持无状态，所有状态应封装在产品对象中
2. **生命周期管理**：
    - 瞬态对象：每次请求新实例（默认方式）
    - 单例对象：使用`Lazy<T>`或双重检查锁定
    - 作用域对象：结合DI容器（[如ASP.NET](http://xn--ASP-eo8e.NET) Core的`IServiceScope`）
3. **并发控制**：

```C#
public class ConcurrentUIFactory : IUIFactory
{
    private readonly object _buttonLock = new object();
    private IButton _cachedButton;

    public IButton CreateButton()
    {
        if (_cachedButton != null) return _cachedButton;
        
        lock (_buttonLock)
        {
            if (_cachedButton == null)
            {
                // 模拟耗时初始化
                Thread.Sleep(1000);
                _cachedButton = new WindowsButton();
            }
            return _cachedButton;
        }
    }
}
```
4. **性能监控**：使用`Interlocked`计数器跟踪对象创建数量

```C#
public class InstrumentedFactory : IUIFactory
{
    private int _buttonCount;
    private int _textBoxCount;

    public IButton CreateButton()
    {
        Interlocked.Increment(ref _buttonCount);
        return new WindowsButton();
    }

    public void PrintStats() => 
        Console.WriteLine($"Buttons: {_buttonCount}, TextBoxes: {_textBoxCount}");
}
```

---

### 五、DI容器集成示例（[ASP.NET](http://ASP.NET) Core）

```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IUIFactory>(provider => 
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return WindowsUIFactory.Instance;
        else
            return MacUIFactory.Instance;
    });

    services.AddTransient<IButton>(provider => 
        provider.GetService<IUIFactory>().CreateButton());
    
    services.AddScoped<ITextBox>(provider => 
        provider.GetService<IUIFactory>().CreateTextBox());
}
```

---

### 六、压力测试建议

```C#
Parallel.For(0, 1000, i => 
{
    var factory = WindowsUIFactory.Instance;
    var button = factory.CreateButton();
    button.Render();
});
```

通过以上设计，可在高并发场景下实现：

- 线程安全的对象创建
- 可控的对象生命周期
- 高效的内存利用率
- 可扩展的工厂体系

实际应用中需根据具体场景选择缓存策略、并发控制方式和对象复用机制，并通过性能测试验证设计有效性。