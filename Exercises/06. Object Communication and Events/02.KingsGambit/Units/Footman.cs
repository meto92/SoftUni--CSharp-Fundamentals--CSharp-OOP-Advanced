public class Footman : Unit
{
    private const string FootmanOnKingAttackedMessage = "Footman {0} is panicking!";

    public Footman(string name)
        : base(name)
    { }

    public override string MessageOnKingAttacked => string.Format(
        FootmanOnKingAttackedMessage, 
        base.Name);
}