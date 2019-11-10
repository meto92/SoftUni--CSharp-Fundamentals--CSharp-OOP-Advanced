using System.Collections.Generic;

public class RecipeFactory : IRecipeFactory
{
    public IRecipe CreateRecipe(string recipeName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitpointsBonus, int damageBonus, IList<string> requiredItems)
    {
        IRecipe recipe = new RecipeItem(
            recipeName,
            strengthBonus,
            agilityBonus,
            intelligenceBonus,
            hitpointsBonus,
            damageBonus,
            requiredItems);

        return recipe;
    }
}