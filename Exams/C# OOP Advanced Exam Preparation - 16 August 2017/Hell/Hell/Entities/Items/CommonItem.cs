public class CommonItem : Item, ICommonItem
{
    public CommonItem(
        string name, 
        long strengthBonus,
        long agilityBonus,
        long intelligenceBonus,
        long hitPointsBonus,
        long damageBonus) 
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    { }
}