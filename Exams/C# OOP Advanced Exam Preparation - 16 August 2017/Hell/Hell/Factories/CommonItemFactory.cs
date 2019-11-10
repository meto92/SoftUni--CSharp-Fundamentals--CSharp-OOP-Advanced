public class CommonItemFactory : ICommonItemFactory
{
    public ICommonItem CreateCommonItem(string itemName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitpointsBonus, int damageBonus)
    {
        ICommonItem commonItem = new CommonItem(
            itemName, 
            strengthBonus, 
            agilityBonus, 
            intelligenceBonus, 
            hitpointsBonus, 
            damageBonus);

        return commonItem;
    }
}