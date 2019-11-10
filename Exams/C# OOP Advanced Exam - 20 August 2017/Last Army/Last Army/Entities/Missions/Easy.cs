public class Easy : Mission
{
    private const string EasyMissionName = "Suppression of civil rebellion";
    private const double EasyMissionEnduranceRequired = 20;
    private const double EasyMissionWearLevelDecrement = 30;

    public Easy(double scoreToComplete) 
        : base(scoreToComplete)
    { }

    public override string Name => EasyMissionName;

    public override double EnduranceRequired => EasyMissionEnduranceRequired;

    public override double WearLevelDecrement => EasyMissionWearLevelDecrement;
}