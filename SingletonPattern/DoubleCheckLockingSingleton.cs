using System;

namespace SingletonPattern;

/// <summary>
/// 双重检查锁定
/// 线程安全，减少锁竞争，提升性能
/// </summary>
public class DoubleCheckLockingSingleton
{
    // 使用 volatile 关键字确保多线程下对 _instance 的修改可见性
    private static volatile DoubleCheckLockingSingleton? _instance;
    private static readonly object Lock = new object();
    
    private DoubleCheckLockingSingleton() {}

    public static DoubleCheckLockingSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DoubleCheckLockingSingleton();
                    }
                }
            }
            return _instance;
        }
    }

    public void Print()
    {
        Console.WriteLine($"Double-Check-Locking Singleton, HashCode: {GetHashCode()}");
    }
}