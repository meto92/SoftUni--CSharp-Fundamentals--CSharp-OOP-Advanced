using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

public class ProviderControllerTests
{
    private const string SuccessfullRegistration = "Successfully registered {0}";
    private const string EnergyProducedToday = "Produced {0} energy today!";
    private const string ProvidersRepaired = "Providers are repaired by {0}";
    private const int RepairValue = 100;
    private const int StandartProviderId = 1;
    private const int StandartProviderEnergyOutput = 25;
    private const int SolarProviderId = 2;
    private const int SolarProviderEnergyOutput = 50;
    private const int PressureProviderId = 3;
    private const int PressureProviderEnergyOutput = 100;

    private static List<string> StandartProviderArgs = new List<string>() {
        "Standart",
        StandartProviderId.ToString(),
        StandartProviderEnergyOutput.ToString()
    };
    private static List<string> SolarProviderArgs = new List<string>() {
        "Solar",
        SolarProviderId.ToString(),
        SolarProviderEnergyOutput.ToString()
    };
    private static List<string> PressureProviderArgs = new List<string>() {
        "Pressure",
        PressureProviderId.ToString(),
        PressureProviderEnergyOutput.ToString()
    };
    private static List<List<string>> ProvidersArgs = new List<List<string>>()
    {
        StandartProviderArgs,
        SolarProviderArgs,
        PressureProviderArgs
    };

    private ProviderController providerController;
    private IEnergyRepository energyRepository;

    [SetUp]
    public void InitObjects()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = 
            new ProviderController(this.energyRepository);
    }

    //[Test]
    public void SuccessfulRegisterShouldReturnRegisterMessage()
    {
        for (int i = 0; i < ProvidersArgs.Count; i++)
        {
            string result = this.providerController.Register(ProvidersArgs[i]);

            Assert.That(result, Is.EqualTo(
                string.Format(
                    SuccessfullRegistration,
                    $"{ProvidersArgs[i][0]}{nameof(Provider)}")));
        }
    }

    [Test]
    public void SuccessfulRegisterShouldIncreaseEntitiesCount()
    {
        this.providerController.Register(StandartProviderArgs);

        Assert.That(this.providerController.Entities.Count,
            Is.EqualTo(1));
    }

    [Test]
    public void ProduceShouldIncreaseTotalEnergyProduced()
    {
        this.providerController.Register(StandartProviderArgs);
        this.providerController.Produce();

        Assert.That(this.providerController.TotalEnergyProduced, 
            Is.EqualTo(StandartProviderEnergyOutput));
    }

    [Test]
    public void ProduceShouldIncreaseEnergyStoredInRepository()
    {
        this.providerController.Register(StandartProviderArgs);

        this.providerController.Produce();

        Assert.That(this.energyRepository.EnergyStored, 
            Is.EqualTo(StandartProviderEnergyOutput));
    }

    //[Test]
    public void ProduceShouldReturnProducedEnergyMessage()
    {
        this.providerController.
            Register(StandartProviderArgs);

        string result = this.providerController.Produce();

        Assert.That(result, Is.EqualTo(string.Format(
            EnergyProducedToday, int.Parse(StandartProviderArgs[2]))));
    }

    [Test]
    public void EmptyControllerShouldProduceZeroEnergy()
    {
        //string result = 
		this.providerController.Produce();

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(0));
        Assert.That(this.energyRepository.EnergyStored, Is.EqualTo(0));
        //Assert.That(result, Is.EqualTo(string.Format(EnergyProducedToday, 0)));
    }

    [Test]
    public void ProduceShouldRemoveEntitiesWithoutDurability()
    {
        ProvidersArgs
            .ForEach(args => this.providerController.Register(args));

        for (int i = 0; i <= 15; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }

    //[Test]
    public void RepairShouldReturnProvidersRepairedMessage()
    {
        string result = this.providerController.Repair(RepairValue);

        Assert.That(result, Is.EqualTo(string.Format(
            ProvidersRepaired,
            RepairValue)));
    }

    [Test]
    public void RepairShouldIncreaseProvidersDurability()
    {
        ProvidersArgs
            .ForEach(args => this.providerController.Register(args));

        Dictionary<IEntity, double> durabilityByEntity = 
            this.providerController.Entities
            .ToDictionary(entity => entity, entity => entity.Durability);

        this.providerController.Repair(RepairValue);

        foreach (IEntity entity in this.providerController.Entities)
        {
            Assert.That(durabilityByEntity[entity],
                Is.EqualTo(entity.Durability - RepairValue));
        }
    }
}