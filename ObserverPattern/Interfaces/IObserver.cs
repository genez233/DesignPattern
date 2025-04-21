namespace ObserverPattern.Interfaces;

/// <summary>
/// 观察者接口
/// </summary>
public interface IObserver
{
    void Update(float temperature);
}