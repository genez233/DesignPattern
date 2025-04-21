using ObserverPattern.Interfaces;

namespace ObserverPattern.Observers;

/// <summary>
/// 实现观察者：网页仪表盘显示
/// </summary>
public class WebDashboard : IObserver
{
    public void Update(float temperature)
    {
        Console.WriteLine($"网页仪表盘收到温度更新： {temperature}°C");
    }
}