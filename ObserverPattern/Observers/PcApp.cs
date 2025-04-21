namespace ObserverPattern.Observers;

/// <summary>
/// 实现观察者：PC应用（内置实现）
/// </summary>
public class PcApp : IObserver<float>
{
    public void OnCompleted()
    {
        Console.WriteLine("PC应用已关闭");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"PC应用出错：{error.Message}");
    }

    public void OnNext(float value)
    {
        Console.WriteLine($"PC应用收到温度更新：{value}");
    }
}