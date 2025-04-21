using ObserverPattern.Interfaces;

namespace ObserverPattern.Observers;

/// <summary>
/// 实现观察者：手机应用
/// </summary>
public class MobileApp : IObserver
{
    public void Update(float temperature)
    {
        Console.WriteLine($"手机应用收到温度更新：{temperature}°C");
    }
}