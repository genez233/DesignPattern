using ObserverPattern.Interfaces;

namespace ObserverPattern.Subjects;

/// <summary>
/// 实现被观察者：天气站
/// </summary>
public class WeatherStation : ISubject
{
    private List<IObserver> _observers = new();
    private float _temperature;
    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature);
        }
    }
    
    /// <summary>
    /// 设置温度，并通知观察者
    /// </summary>
    /// <param name="temperature"></param>
    public void SetTemperature(float temperature)
    {
        _temperature = temperature;
        NotifyObservers();
    }
}