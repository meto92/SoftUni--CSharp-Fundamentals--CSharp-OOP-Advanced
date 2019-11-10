public class Assassin : AbstractHero
{
    private const int AssassinInitialStrength = 25;
    private const int AssassinInitialAgility = 100;
    private const int AssassinInitialIntelligence = 15;
    private const int AssassinInitialHitPoints = 150;
    private const int AssassinInitialDamage = 300;

    public Assassin(
        string name)
        : base(
            name,
            AssassinInitialStrength,
            AssassinInitialAgility,
            AssassinInitialIntelligence,
            AssassinInitialHitPoints,
            AssassinInitialDamage)
    { }
}