public interface ICommonItemFactory
{
    ICommonItem CreateCommonItem(string itemName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitpointsBonus, int damageBonus);
}