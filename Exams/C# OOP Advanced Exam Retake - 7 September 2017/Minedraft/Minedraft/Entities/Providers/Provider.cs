using System;

public abstract class Provider : Entity, IProvider
{
    private const int InitialDurability = 1000;
    private const int DurabilityLostEveryDay = 100;

    private double energyOutput;

    protected Provider(int id, double energyOutput)
        : base(id, InitialDurability)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        private set => this.energyOutput = value;
    }

    public override void Broke()
    {
        if (this.Durability <= 0)
        {
            throw new InvalidOperationException();
        }

        this.Durability -= DurabilityLostEveryDay;
    }

    public override double Produce() => this.EnergyOutput;

    public void Repair(double val) => base.Durability += val;
}