public class Medium : Mission
{
    private const string MediumMissionName = "Capturing dangerous criminals";
    private const double MediumMissionEnduranceRequired = 50;
    private const double MediumMissionWearLevelDecrement = 50;

    public Medium(double scoreToComplete)
        : base(scoreToComplete)
    { }

    public override string Name => MediumMissionName;

    public override double EnduranceRequired => MediumMissionEnduranceRequired;

    public override double WearLevelDecrement => MediumMissionWearLevelDecrement;
}