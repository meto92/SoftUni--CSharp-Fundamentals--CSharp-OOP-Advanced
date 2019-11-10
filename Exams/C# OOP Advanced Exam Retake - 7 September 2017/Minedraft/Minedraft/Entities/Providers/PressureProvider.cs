public class PressureProvider : Provider
{
    private const int DurabilityToDecrease = 300;
    private const int EnergyOutputMultiplier = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput * EnergyOutputMultiplier)
    {
        base.Durability -= DurabilityToDecrease;
    }
}