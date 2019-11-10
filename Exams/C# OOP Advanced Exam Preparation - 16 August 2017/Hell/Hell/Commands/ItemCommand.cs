using System.Collections.Generic;

public class ItemCommand : Command
{
    [Inject]
    private ICommonItemFactory commonItemFactory;

    public ItemCommand(IList<string> arguments, IManager manager) 
        : base(arguments, manager)
    { }

    public override string Execute()
    {
        string itemName = base.Arguments[0];
        string heroName = base.Arguments[1];
        int strengthBonus = int.Parse(base.Arguments[2]);
        int agilityBonus = int.Parse(base.Arguments[3]);
        int intelligenceBonus = int.Parse(base.Arguments[4]);
        int hitpointsBonus = int.Parse(base.Arguments[5]);
        int damageBonus = int.Parse(base.Arguments[6]);

        ICommonItem commonItem = this.commonItemFactory.CreateCommonItem(
            itemName, 
            strengthBonus,
            agilityBonus, 
            intelligenceBonus, 
            hitpointsBonus, 
            damageBonus);

        string result = base.Manager.AddItemToHero(commonItem, heroName);

        return result;
    }
}