public class Sword : Weapon
{
    private const int SwordMinDamage = 4;
    private const int SwordMaxDamage = 6;
    private const int SwordSocketsCount = 3;

    public Sword(string name, RarityLevel rarityLevel)
        : base(name, SwordMinDamage, SwordMaxDamage, SwordSocketsCount, rarityLevel)
    { }
}