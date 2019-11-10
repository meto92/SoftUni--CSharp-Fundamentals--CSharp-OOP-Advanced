using System;

public abstract class Entity : IEntity
{
    private int id;
    private double durability;

    protected Entity(int id, double durability)
    {
        this.ID = id;
        this.Durability = durability;
    }

    public int ID
    {
        get => this.id;
        private set => this.id = value;
    }

    public virtual double Durability
    {
        get => this.durability;
        protected set => this.durability = value;
    }

    public abstract void Broke();

    public abstract double Produce();

    public override string ToString()
    {
        return $"{this.GetType().Name}{Environment.NewLine}Durability: {this.Durability}";
    }
}