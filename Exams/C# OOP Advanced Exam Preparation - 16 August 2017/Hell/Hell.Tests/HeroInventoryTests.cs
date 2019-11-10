using System.Collections.Generic;

using NUnit.Framework;

public class HeroInventoryTests
{
    private const string ItemName = "Knife";
    private const string RecipeName = "Spear";
    private const int StrengthBonus = 10;
    private const int AgilityBonus = 20;
    private const int IntelligenceBonus = 30;
    private const int HitPointsBonus = 40;
    private const int DamageBonus = 50;

    private HeroInventory heroInventry;
    private CommonItem item;

    //[SetUp]
    //public void InitInventory()
    //{
    //    this.heroInventry = new HeroInventory();
    //    this.item = new CommonItem(ItemName, StrengthBonus, AgilityBonus, IntelligenceBonus, HitPointsBonus, DamageBonus);
    //}

    //public void CheckBonuses()
    //{
    //    Assert.That(this.heroInventry.TotalStrengthBonus, Is.EqualTo(StrengthBonus));
    //    Assert.That(this.heroInventry.TotalAgilityBonus, Is.EqualTo(AgilityBonus));
    //    Assert.That(this.heroInventry.TotalIntelligenceBonus, Is.EqualTo(IntelligenceBonus));
    //    Assert.That(this.heroInventry.TotalHitPointsBonus, Is.EqualTo(HitPointsBonus));
    //    Assert.That(this.heroInventry.TotalDamageBonus, Is.EqualTo(DamageBonus));
    //}

    //[Test]
    //public void AddingItemShouldIncreaseBonuses()
    //{
    //    this.heroInventry.AddCommonItem(this.item);

    //    this.CheckBonuses();
    //}

    //[Test]
    //public void AddingRecipeWithoutRequiredItemsShouldCreateCommonItemFromIt()
    //{
    //    IRecipe recipe = new RecipeItem(RecipeName, StrengthBonus, AgilityBonus, IntelligenceBonus, HitPointsBonus, DamageBonus, new List<string>() { });
    //    this.heroInventry.AddRecipeItem(recipe);

    //    this.CheckBonuses();
    //}

    //[Test]
    //public void CreatingItemFromRecipeShouldRemoveItem()
    //{
    //    this.heroInventry.AddCommonItem(this.item);
    //    IRecipe recipe = new RecipeItem(RecipeName, StrengthBonus, AgilityBonus, IntelligenceBonus, HitPointsBonus, DamageBonus, new List<string>() { ItemName });

    //    this.heroInventry.AddRecipeItem(recipe);

    //    this.CheckBonuses();
    //}
}