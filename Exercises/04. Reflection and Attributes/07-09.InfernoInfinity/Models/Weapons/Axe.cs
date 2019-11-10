public class Axe : Weapon
{
    private const int AxeMinDamage = 5;
    private const int AxeMaxDamage = 10;
    private const int AxeSocketsCount = 4;

    public Axe(string name, RarityLevel rarityLevel)
        : base(name, AxeMinDamage, AxeMaxDamage, AxeSocketsCount, rarityLevel)
    { }
}