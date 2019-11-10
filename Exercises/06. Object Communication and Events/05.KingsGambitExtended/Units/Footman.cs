public class Footman : Unit
{
    private const int FootmanHitsToTake = 2;
    private const string FootmanOnKingAttackedMessage = "Footman {0} is panicking!";

    public Footman(string name)
        : base(name, FootmanHitsToTake)
    { }

    public override string MessageOnKingAttacked => string.Format(
        FootmanOnKingAttackedMessage, 
        base.Name);
}