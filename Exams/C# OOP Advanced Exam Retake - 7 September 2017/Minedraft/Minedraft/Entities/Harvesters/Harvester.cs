public abstract class Harvester : Entity, IHarvester
{
    private const int InitialDurability = 1000;
    private const int EnergyLostOnModeChange = 100;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(int id, double oreOutput, double energyRequirement)
        : base(id, InitialDurability)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set => this.oreOutput = value;
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set => this.energyRequirement = value;
    }

    public override void Broke()
    {
        base.Durability -= EnergyLostOnModeChange;
    }

    public override double Produce() => this.OreOutput;
}