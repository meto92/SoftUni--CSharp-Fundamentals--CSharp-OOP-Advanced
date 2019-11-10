public class RoyalGuard : Unit
{
    private const int RoyalGuardHitsToTake = 3;
    private const string RoyalGuardOnKingAttackedMessage = "Royal Guard {0} is defending!";

    public RoyalGuard(string name)
        : base(name, RoyalGuardHitsToTake)
    { }

    public override string MessageOnKingAttacked => string.Format(
        RoyalGuardOnKingAttackedMessage, 
        base.Name);
}