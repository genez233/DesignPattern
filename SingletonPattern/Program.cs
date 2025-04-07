// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using SingletonPattern;

Console.WriteLine("单例模式!");

#region 懒汉式

// 多线程并发访问
Parallel.For(1, 20, (_) =>
{
    LazySingleton.Instance.Print();
});

#endregion

Console.WriteLine(new string('=', 50));

#region 饿汉式

// 多线程并发访问
Parallel.For(1, 20, (_) =>
{
    HungrySingleton.Instance.Print();
});

#endregion

Console.WriteLine(new string('=', 50));

#region 双重检查锁定

// 多线程并发访问
Parallel.For(1, 20, (_) =>
{
    DoubleCheckLockingSingleton.Instance.Print();
});

#endregion

Console.WriteLine(new string('=', 50));

#region Lazy<T> 自动处理

// 多线程并发访问
Parallel.For(1, 20, (_) =>
{
    LazyTSinleton.Instance.Print();
});

#endregion

Console.WriteLine(new string('=', 50));

#region 构造函数

// 多线程并发访问
Parallel.For(1, 20, (_) =>
{
    StaticSingleton.Instance.Print();
});

#endregion