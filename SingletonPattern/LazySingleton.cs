namespace SingletonPattern;

/// <summary>
/// 非线程安全的懒汉式（延迟初始化）
/// q：多线程下可能创建多个实例
/// </summary>
public class LazySingleton
{
    private static LazySingleton? _instance;
    
    // 私有构造函数
    private LazySingleton() {}

    public static LazySingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LazySingleton();
            }
            
            return _instance;
        }
    }

    public void Print()
    {
        Console.WriteLine($"Lazy Singleton, Hash Code: {GetHashCode()}");
    }
}