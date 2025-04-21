namespace ObserverPattern.Interfaces;

/// <summary>
/// 被观察者接口
/// </summary>
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}