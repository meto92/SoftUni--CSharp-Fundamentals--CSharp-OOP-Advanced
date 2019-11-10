public class SolarProvider : Provider
{
    private const int AdditionalDurability = 500;

    public SolarProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        base.Durability += AdditionalDurability;
    }
}