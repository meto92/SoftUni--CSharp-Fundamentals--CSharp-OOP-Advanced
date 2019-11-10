public class RoyalGuard : Unit
{
    private const string RoyalGuardOnKingAttackedMessage = "Royal Guard {0} is defending!";

    public RoyalGuard(string name)
        : base(name)
    { }

    public override string MessageOnKingAttacked => string.Format(
        RoyalGuardOnKingAttackedMessage, 
        base.Name);
}