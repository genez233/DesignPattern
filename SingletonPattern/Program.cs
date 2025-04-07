// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using SingletonPattern;

Console.WriteLine("单例模式!");

#region 懒汉式

// 多线程并发访问
Parallel.For(1, 20, (i) =>
{
    LazySingleton.Instance.Print();
});

#endregion

Console.WriteLine(new string('=', 50));

#region 饿汉式

// 多线程并发访问
Parallel.For(1, 20, (i) =>
{
    HungrySingleton.Instance.Print();
});

#endregion

Console.WriteLine(new string('=', 50));

#region 双重检查锁定

// 多线程并发访问
Parallel.For(1, 20, (i) =>
{
    DoubleCheckLockingSingleton.Instance.Print();
});

#endregion

Console.WriteLine(new string('=', 50));

#region Lazy<T> 自动处理

// 多线程并发访问
Parallel.For(1, 20, (i) =>
{
    LazyTSinleton.Instance.Print();
});

#endregion

Console.WriteLine(new string('=', 50));

#region 构造函数

// 多线程并发访问
Parallel.For(1, 20, (i) =>
{
    StaticSingleton.Instance.Print();
});

#endregion