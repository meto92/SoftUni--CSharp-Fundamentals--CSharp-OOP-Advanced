public class Knife : Weapon
{
    private const int KnifeMinDamage = 3;
    private const int KnifeMaxDamage = 4;
    private const int KnifeSocketsCount = 2;

    public Knife(string name, RarityLevel rarityLevel)
        : base(name, KnifeMinDamage, KnifeMaxDamage, KnifeSocketsCount, rarityLevel)
    { }
}