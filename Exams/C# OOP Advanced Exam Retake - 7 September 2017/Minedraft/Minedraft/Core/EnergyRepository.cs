public class EnergyRepository : IEnergyRepository
{
    private double energyStored;

    public EnergyRepository()
    {
        this.EnergyStored = 0;
    }

    public double EnergyStored
    {
        get => this.energyStored;
        set => this.energyStored = value;
    }

    public void StoreEnergy(double energy) => this.EnergyStored += energy;

    public bool TakeEnergy(double energyNeeded)
    {
        if (this.EnergyStored >= energyNeeded)
        {
            this.EnergyStored -= energyNeeded;

            return true;
        }

        return false;
    }
}