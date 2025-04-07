namespace SingletonPattern;

/// <summary>
/// 静态构造函数
/// 由 CLR 保证静态构造函数只执行一次，线程安全，但实例在首次访问静态成员时创建，即便该实例并未被使用（不是延迟初始化）。
/// </summary>
public class StaticSingleton
{
    private static readonly StaticSingleton _instance;

    static StaticSingleton()
    {
        _instance = new StaticSingleton();
    }

    private StaticSingleton() {}

    public static StaticSingleton Instance => _instance;

    public void Print()
    {
        Console.WriteLine($"Static Singleton, Hash Code: {GetHashCode()}");
    }
}