public class Barbarian : AbstractHero
{
    private const int BarbarianInitialStrength = 90;
    private const int BarbarianInitialAgility = 25;
    private const int BarbarianInitialIntelligence = 10;
    private const int BarbarianInitialHitPoints = 350;
    private const int BarbarianInitialDamage = 150;

    public Barbarian(
        string name) 
        : base(
            name,
            BarbarianInitialStrength,
            BarbarianInitialAgility,
            BarbarianInitialIntelligence,
            BarbarianInitialHitPoints,
            BarbarianInitialDamage)
    { }
}