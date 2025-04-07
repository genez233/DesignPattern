namespace SingletonPattern;

/// <summary>
/// 使用 Lazy<T> 自动处理线程安全和延迟初始化
/// Lazy<T> 是.NET Framework 4+ 提供的类
/// </summary>
public class LazyTSinleton
{
    // LazyThreadSafetyMode.ExecutionAndPublication 确保线程安全和高效初始化。
    private static readonly Lazy<LazyTSinleton> _instance =
        new Lazy<LazyTSinleton>(() => new LazyTSinleton(), LazyThreadSafetyMode.ExecutionAndPublication);

    private LazyTSinleton() {}

    public static LazyTSinleton Instance => _instance.Value;

    public void Print()
    {
        Console.WriteLine($"Lazy<T> Singleton, HashCode: {GetHashCode()}");
    }
}