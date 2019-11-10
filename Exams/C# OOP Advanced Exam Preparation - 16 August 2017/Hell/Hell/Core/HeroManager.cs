using System.Linq;
using System.Text;
using System.Collections.Generic;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IHero hero)
    {
        this.heroes[hero.Name] = hero;

        string result = string.Format(
            Constants.HeroCreateMessage,
            hero.GetType().Name, hero.Name);

        return result;
    }

    public string AddItemToHero(IItem item, string heroName)
    {
        this.heroes[heroName].Inventory.AddCommonItem(item);

        string result = string.Format(Constants.ItemCreateMessage, item.Name, heroName);

        return result;
    }

    public string AddRecipeToHero(IRecipe recipe, string heroName)
    {
        this.heroes[heroName].Inventory.AddRecipeItem(recipe);

        string result = string.Format(Constants.RecipeCreatedMessage, recipe.Name, heroName);

        return result;
    }
    
    public string InspectHero(string heroName)
    {
        string result = this.heroes[heroName].ToString();

        return result;
    }

    public string GetHeroesInfo()
    {
        List<IHero> heroes = this.heroes.Values
            .OrderByDescending(hero => hero)
            .ToList();

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < heroes.Count; i++)
        {
            IHero hero = heroes[i];

            result.AppendLine($"{i + 1}. {hero.GetType().Name}: {hero.Name}");
            result.AppendLine($"###HitPoints: {hero.HitPoints}");
            result.AppendLine($"###Damage: {hero.Damage}");
            result.AppendLine($"###Strength: {hero.Strength}");
            result.AppendLine($"###Agility: {hero.Agility}");
            result.AppendLine($"###Intelligence: {hero.Intelligence}");
            result.Append($"###Items: ");

            ICollection<IItem> heroItems = hero.Items;

            if (heroItems.Count == 0)
            {
                result.AppendLine("None");
            }
            else
            {
                result.AppendLine(string.Join(", ", heroItems.Select(item => item.Name)));
            }
        }

        return result.ToString().TrimEnd();
    }
}