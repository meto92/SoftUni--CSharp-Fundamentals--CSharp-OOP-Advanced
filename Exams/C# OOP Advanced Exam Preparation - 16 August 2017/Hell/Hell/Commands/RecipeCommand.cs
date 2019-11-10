using System.Linq;
using System.Collections.Generic;

public class RecipeCommand : Command
{
    [Inject]
    private IRecipeFactory recipeFactory;

    public RecipeCommand(IList<string> arguments, IManager manager)
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
        IList<string> requiredItems = base.Arguments.Skip(7).ToList();

        IRecipe recipe = this.recipeFactory.CreateRecipe(
            itemName, 
            strengthBonus, 
            agilityBonus, 
            intelligenceBonus, 
            hitpointsBonus, 
            damageBonus, 
            requiredItems);

        string result = base.Manager.AddRecipeToHero(recipe, heroName);

        return result;
    }
}