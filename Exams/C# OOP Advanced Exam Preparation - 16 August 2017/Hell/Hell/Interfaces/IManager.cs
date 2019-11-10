public interface IManager
{
    string AddHero(IHero hero);

    string AddItemToHero(IItem item, string heroName);

    string AddRecipeToHero(IRecipe recipe, string heroName);

    string InspectHero(string heroName);

    string GetHeroesInfo();
}