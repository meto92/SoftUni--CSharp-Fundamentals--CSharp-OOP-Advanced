﻿using System.Linq;
using System.Collections.Generic;

public class HeroInventory : IInventory
{
    [Item]
    private Dictionary<string, IItem> commonItems;

    private Dictionary<string, IRecipe> recipeItems;

    public HeroInventory()
    {
        this.commonItems = new Dictionary<string, IItem>();
        this.recipeItems = new Dictionary<string, IRecipe>();
    }

    public long TotalStrengthBonus
    {
        get => this.commonItems.Values.Sum(i => i.StrengthBonus);
    }

    public long TotalAgilityBonus
    {
        get => this.commonItems.Values.Sum(i => i.AgilityBonus);
    }

    public long TotalIntelligenceBonus
    {
        get => this.commonItems.Values.Sum(i => i.IntelligenceBonus);
    }

    public long TotalHitPointsBonus
    {
        get => this.commonItems.Values.Sum(i => i.HitPointsBonus);
    }

    public long TotalDamageBonus
    {
        get => this.commonItems.Values.Sum(i => i.DamageBonus);
    }

    public void AddCommonItem(IItem item)
    {
        this.commonItems.Add(item.Name, item);
        this.CheckRecipes();
    }

    public void AddRecipeItem(IRecipe recipe)
    {
        this.recipeItems.Add(recipe.Name, recipe);
        this.CheckRecipes();
    }

    private void CheckRecipes()
    {
        foreach (IRecipe recipe in this.recipeItems.Values)
        {
            List<string> requiredItems = new List<string>(recipe.RequiredItems);

            foreach (IItem commonItem in this.commonItems.Values)
            {
                if (requiredItems.Contains(commonItem.Name))
                {
                    requiredItems.Remove(commonItem.Name);
                }
            }

            if (requiredItems.Count == 0)
            {
                this.CombineRecipe(recipe);
            }
        }
    }

    private void CombineRecipe(IRecipe recipe)
    {
        for (int i = 0; i < recipe.RequiredItems.Count; i++)
        {
            string item = recipe.RequiredItems[i];
            this.commonItems.Remove(item);
        }

        IItem newItem = new CommonItem(recipe.Name,
            recipe.StrengthBonus,
            recipe.AgilityBonus,
            recipe.IntelligenceBonus,
            recipe.HitPointsBonus,
            recipe.DamageBonus);

        this.commonItems.Add(newItem.Name, newItem);
    }
}