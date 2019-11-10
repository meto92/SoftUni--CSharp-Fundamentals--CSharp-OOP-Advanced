using NUnit.Framework;

public class MissionControllerTests
{
    private IMission mission;
    private IWareHouse wareHouse;
    private MissionController missionController;

    [SetUp]
    public void InitObjects()
    {
        this.mission = new Hard(0);
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(new Army(), wareHouse);
    }

    [Test]
    public void SuccessfulMissionShouldReturnCompletedMissionMessage()
    {
        string result = this.missionController.PerformMission(this.mission).TrimEnd();

        Assert.True(result.StartsWith("Mission completed"));
    }

    [Test]
    public void FailedMissionShouldReturnMissionOnHoldMessage()
    {
        this.mission = new Easy(1);
        this.missionController = new MissionController(new Army(), this.wareHouse);

        string result = this.missionController
            .PerformMission(this.mission);

        Assert.True(result.StartsWith("Mission on hold"));
    }

    [Test]
    public void PerformMissionShouldDeclineMissionWhenFourthMissionIsAdded()
    {
        this.mission = new Easy(1);

        string result = null;

        for (int i = 0; i < 4; i++)
        {
            result = this.missionController.PerformMission(this.mission);
        }

        Assert.True(result.StartsWith("Mission declined"));
    }
}