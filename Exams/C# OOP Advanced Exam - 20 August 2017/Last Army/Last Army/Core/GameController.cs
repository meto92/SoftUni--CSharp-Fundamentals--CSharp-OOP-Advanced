using System;
using System.Linq;
using System.Text;

public class GameController : IGameController
{
    private const string RegenerateCommand = "Regenerate";
    private const string SuccessfulMissionsMessage = "Successful missions - {0}";
    private const string FailedMissionsMessage = "Failed missions - {0}";
    private const string ResultsMessage = "Results:";
    private const string SoldiersMessage = "Soldiers:";

    private IArmy army;
    private IWriter writer;
    private IWareHouse wareHouse;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IMissionController missionController;

    public GameController(
        IArmy army, 
        IWriter writer, 
        IWareHouse wareHouse,
        ISoldierFactory soldierFactory, 
        IMissionFactory missionFactory, 
        IMissionController missionController)
    {
        this.army = army;
        this.writer = writer;
        this.wareHouse = wareHouse;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
        this.missionController = missionController;
    }

    private void AddSoldierToArmy(string[] soldierParams)
    {
        string soldierType = soldierParams[0];
        string name = soldierParams[1];
        int age = int.Parse(soldierParams[2]);
        double experience = double.Parse(soldierParams[3]);
        double endurance = double.Parse(soldierParams[4]);

        ISoldier soldier = this.soldierFactory.
            CreateSoldier(soldierType, name, age, experience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new InvalidOperationException(
                string.Format(
                    OutputMessages.NoWeaponForSoldier,
                    soldier.GetType().Name, soldier.Name));
        }

        this.army.AddSoldier(soldier);
    }

    public void InterpretCommand(string input)
    {
        string[] data = input.Split();

        switch (data[0])
        {
            case nameof(WareHouse):
                string ammunitionType = data[1];
                int count = int.Parse(data[2]);

                this.wareHouse.AddAmmunitions(ammunitionType, count);
                break;
            case nameof(Soldier):

                switch (data[1])
                {
                    case RegenerateCommand:
                        string soldierType = data[2];

                        this.army.RegenerateTeam(soldierType);
                        break;
                    default:
                        this.AddSoldierToArmy(data.Skip(1).ToArray());
                        break;
                }

                break;
            case nameof(Mission):
                string difficultyLevel = data[1];
                double scoreToComplete = double.Parse(data[2]);

                IMission mission = this.missionFactory
                    .CreateMission(difficultyLevel, scoreToComplete);

                this.writer.WriteLine(this.missionController.PerformMission(mission).TrimEnd());
                break;
        }
    }
    
    private void PrintStatistics()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine(ResultsMessage);
        result.AppendLine(string.Format(
            SuccessfulMissionsMessage,
            this.missionController.SuccessMissionCounter));
        result.AppendLine(string.Format(
            FailedMissionsMessage, 
            this.missionController.FailedMissionCounter));
        result.AppendLine(SoldiersMessage);

        foreach (ISoldier soldier
            in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            result.AppendLine(soldier.ToString());
        }

        this.writer.WriteLine(result.ToString().TrimEnd());
    }

    public void ProduceSummary()
    {
        this.missionController.FailMissionsOnHold();
        this.PrintStatistics();
    }
}