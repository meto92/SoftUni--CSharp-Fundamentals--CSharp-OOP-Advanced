public interface IMissionController
{
    int FailedMissionCounter { get; }

    int SuccessMissionCounter { get; }

    string PerformMission(IMission mission);

    void FailMissionsOnHold();
}