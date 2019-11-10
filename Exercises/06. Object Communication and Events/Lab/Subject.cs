using System.Collections.Generic;

public class Subject : ISubject
{
    private HashSet<IObserver> observers;

    public Subject()
    {
        this.observers = new HashSet<IObserver>();
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
        foreach (IObserver observer in this.observers)
        {
            observer.Update(1);
        }
    }
}