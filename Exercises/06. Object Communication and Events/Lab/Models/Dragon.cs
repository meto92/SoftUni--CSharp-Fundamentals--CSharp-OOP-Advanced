using System;
using System.Collections.Generic;

public class Dragon : IObservableTarget
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private IHandler handler;
    private HashSet<IObserver> observers;

    public Dragon(string id, int hp, int reward, IHandler handler)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.handler = handler;
        this.observers = new HashSet<IObserver>();
    }

    public bool IsDead => this.hp <= 0;
    
    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if(this.IsDead && !eventTriggered)
        {
            Console.WriteLine(THIS_DIED_EVENT, this);
            this.eventTriggered = true;

            this.NotifyObservers();
        }
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
            observer.Update(this.reward);
        }
    }

    public override string ToString() => this.id;
}