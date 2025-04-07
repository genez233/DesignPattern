# 单例模式

在 C# 中，单例模式（Singleton Pattern）是确保一个类只有一个实例，并提供全局访问点的一种设计模式。在高并发和多线程环境中，实现线程安全的单例模式需要特别注意同步问题。以下是详细的实现方式和优化策略：

---

### 一、单例模式基础实现

#### 1. 非线程安全的懒汉式（延迟初始化）

```C#
public class Singleton
{
    private static Singleton _instance;

    private Singleton() { } // 私有构造函数

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}
```

**问题**：多线程环境下可能创建多个实例。

---

#### 2. 饿汉式（提前初始化）

```C#
public class Singleton
{
    private static readonly Singleton _instance = new Singleton();

    private Singleton() { }

    public static Singleton Instance => _instance;
}
```

**特点**：线程安全，但实例在程序启动时就被创建，可能浪费资源。

---

### 二、多线程安全的单例实现

#### 1. 使用双重检查锁定（Double-Check Locking）

```C#
public class Singleton
{
    private static volatile Singleton _instance;
    private static readonly object _lock = new object();

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }
}
```

**关键点**：

- `volatile` 关键字确保多线程下对 `_instance` 的修改可见性。
- 双重检查减少锁竞争，提升性能。

---

#### 2. 使用 Lazy<T>（推荐方式）

.NET Framework 4+ 提供了 `Lazy<T>` 类，自动处理线程安全和延迟初始化：

```C#
public class Singleton
{
    private static readonly Lazy<Singleton> _lazyInstance = 
        new Lazy<Singleton>(() => new Singleton(), LazyThreadSafetyMode.ExecutionAndPublication);

    private Singleton() { }

    public static Singleton Instance => _lazyInstance.Value;
}
```

**优势**：

- 简洁且线程安全。
- `LazyThreadSafetyMode.ExecutionAndPublication` 确保线程安全和高效初始化。

---

#### 3. 使用静态构造函数

```C#
public class Singleton
{
    private static readonly Singleton _instance;

    static Singleton()
    {
        _instance = new Singleton();
    }

    private Singleton() { }

    public static Singleton Instance => _instance;
}
```

**特点**：

- 由 CLR 保证静态构造函数只执行一次。
- 线程安全，但实例在首次访问静态成员时创建。

---

### 三、高并发场景下的优化

#### 1. 避免锁竞争

- 使用 `Lazy<T>` 或静态初始化，避免显式锁机制。
- 双重检查锁定需配合 `volatile` 关键字确保正确性。

#### 2. 无锁模式（Interlocked）

```C#
public class Singleton
{
    private static Singleton _instance;

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                var temp = new Singleton();
                Interlocked.CompareExchange(ref _instance, temp, null);
            }
            return _instance;
        }
    }
}
```

**特点**：通过原子操作（CAS）避免锁，但可能生成多余临时对象。

---

### 四、总结与最佳实践

|**实现方式**|**线程安全**|**延迟初始化**|**性能**|**复杂度**|
|-|-|-|-|-|
|饿汉式|是|否|高|低|
|双重检查锁定|是|是|中|中|
|`Lazy<T>`|是|是|高|低|
|静态构造函数|是|是（首次访问）|高|低|

**应用场景**
- 数据库连接池
- 配置管理

**推荐选择**：

- **优先使用 ****`Lazy<T>`**：代码简洁，性能优秀，适合大多数场景。
- 需要兼容旧版 .NET 时，使用 **双重检查锁定**。
- 不要求延迟初始化时，用 **饿汉式**。

---

### 五、注意事项

1. **反序列化问题**：序列化/反序列化可能破坏单例，需实现 `ISerializable` 接口。
2. **反射攻击**：通过反射调用私有构造函数可能破坏单例，可在构造函数中添加防御代码：

```C#
private Singleton()
{
    if (_instance != null)
    {
        throw new InvalidOperationException("Singleton instance already exists.");
    }
}
```

通过合理选择实现方式，可以在 C# 中高效、安全地实现单例模式。