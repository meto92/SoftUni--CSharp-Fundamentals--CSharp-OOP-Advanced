using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

public abstract class AbstractHero : IHero, IComparable<IHero>
{
    private IInventory inventory;
    private string name;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public long Strength
    {
        get => this.strength + this.inventory.TotalStrengthBonus;
        set => this.strength = value;
    }

    public long Agility
    {
        get => this.agility + this.inventory.TotalAgilityBonus;
        set => this.agility = value;
    }

    public long Intelligence
    {
        get => this.intelligence + this.inventory.TotalIntelligenceBonus;
        set => this.intelligence = value;
    }

    public long HitPoints
    {
        get => this.hitPoints + this.inventory.TotalHitPointsBonus;
        set => this.hitPoints = value;
    }

    public long Damage
    {
        get => this.damage + this.inventory.TotalDamageBonus;
        set => this.damage = value;
    }

    public long PrimaryStats
    {
        get => this.Strength + this.Agility + this.Intelligence;
    }

    public long SecondaryStats
    {
        get => this.HitPoints + this.Damage;
    }

    public IInventory Inventory => this.inventory;

    private ICollection<IItem> GetItems()
    {
        object field = this.inventory.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(f => f.FieldType == typeof(Dictionary<string, IItem>) &&
                f.CustomAttributes
                    .Any(a => a.AttributeType == typeof(ItemAttribute)))
            .GetValue(this.inventory);

        ICollection<IItem> items = ((Dictionary<string, IItem>) field).Values;

        return items;
    }

    public ICollection<IItem> Items => GetItems();

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }
    
    public int CompareTo(IHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other == null)
        {
            return 1;
        }

        int primary = this.PrimaryStats.CompareTo(other.PrimaryStats);

        if (primary != 0)
        {
            return primary;
        }

        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}");
        result.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        result.AppendLine($"Strength: {this.Strength}");
        result.AppendLine($"Agility: {this.Agility}");
        result.AppendLine($"Intelligence: {this.Intelligence}");
        result.Append($"Items:");

        if (this.Items.Count == 0)
        {
            result.Append(" None");

            return result.ToString();
        }

        result.AppendLine();

        foreach (IItem item in this.Items)
        {
            result.AppendLine(item.ToString());
        }

        return result.ToString().TrimEnd();
    }
}