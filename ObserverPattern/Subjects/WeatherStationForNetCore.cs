namespace ObserverPattern.Subjects;

/// <summary>
/// 实现被观察者：天气站（IObservable<'T'>）
/// </summary>
public class WeatherStationForNetCore : IObservable<float>
{
    private List<IObserver<float>> _observers = new();
    public IDisposable Subscribe(IObserver<float> observer)
    {
        _observers.Add(observer);
        return new Unsubscriber(_observers, observer);
    }
    
    private class Unsubscriber : IDisposable
    {
        private List<IObserver<float>> _observers;
        private IObserver<float> _observer;
        
        public Unsubscriber(List<IObserver<float>> observers, IObserver<float> observer)
        {
            _observers = observers;
            _observer = observer;
        }
        
        public void Dispose()
        {
            // TODO release managed resources here
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
    
    public void SetTemperature(float temperature)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(temperature);
        }
    }
}