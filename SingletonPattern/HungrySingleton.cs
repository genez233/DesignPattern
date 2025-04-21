using System;

namespace SingletonPattern;

/// <summary>
/// 饿汉式（提前初始化）
/// 线程是安全的，但实例在程序启动时就被创建，可能浪费资源。
/// </summary>
public class HungrySingleton
{
    private static readonly HungrySingleton _instance = new HungrySingleton();
    
    private HungrySingleton() {}

    public static HungrySingleton Instance => _instance;

    public void Print()
    {
        Console.WriteLine($"Hungry Singleton, Hash Code: {GetHashCode()}");
    }
}