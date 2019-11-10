using System;
using System.Linq;
using System.Collections.Generic;

public class HarvesterController : IHarvesterController
{
    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;
    private WorkMode workMode;
    private double oreProduced;
    private List<IHarvester> harvesters;

    public HarvesterController(
        IHarvesterFactory harvesterFactory, 
        IEnergyRepository energyRepository)
    {
        this.harvesterFactory = harvesterFactory;
        this.energyRepository = energyRepository;
        this.workMode = WorkMode.Full;
        this.OreProduced = 0;
        this.harvesters = new List<IHarvester>();
    }

    public double OreProduced
    {
        get => this.oreProduced;
        private set => this.oreProduced = value;
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.workMode = (WorkMode) Enum.Parse(typeof(WorkMode), mode, true);

        for (int i = this.harvesters.Count - 1; i >= 0; i--)
        {
            this.harvesters[i].Broke();

            if (this.harvesters[i].Durability <= 0)
            {
                this.harvesters.RemoveAt(i);
            }
        }

        return string.Format(Constants.ModeChanged, this.workMode);
    }

    public string Produce()
    {
        double multiplier = (double) this.workMode / 100;

        double energyRequirement = multiplier * this.harvesters.Sum(h => h.EnergyRequirement);
        double oreProduced = 0;

        if (this.energyRepository.EnergyStored >= energyRequirement)
        {
            oreProduced = multiplier * this.harvesters.Sum(h => h.Produce());
            this.energyRepository.TakeEnergy(energyRequirement);
            this.OreProduced += oreProduced;
        }

        return string.Format(Constants.OreOutputToday, oreProduced);
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(
            Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }
}