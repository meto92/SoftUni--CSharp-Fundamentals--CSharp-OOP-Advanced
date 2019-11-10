using System.Collections.Generic;

public class Jobs : ISubject
{
    private List<IObserver> observers;

    public Jobs()
    {
        this.observers = new List<IObserver>();
    }

    public void Register(IObserver observer)
    {
        this.observers.Add(observer);
    }

    public void Unregister(IObserver observer)
    {
        this.observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        for (int i = 0; i < this.observers.Count; i++)
        {
            this.observers[i].Update();
        }
    }
}