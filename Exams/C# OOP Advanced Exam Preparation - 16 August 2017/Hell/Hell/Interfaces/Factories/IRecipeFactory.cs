using System.Collections.Generic;

public interface IRecipeFactory
{
    IRecipe CreateRecipe(string recipeName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitpointsBonus, int damageBonus, IList<string> requiredItems);
}