using System.Text;

public abstract class Item : IItem
{
    private string name;
    private long strengthBonus;
    private long agilityBonus;
    private long intelligenceBonus;
    private long hitPointsBonus;
    private long damageBonus;

    protected Item(
        string name, 
        long strengthBonus,
        long agilityBonus,
        long intelligenceBonus,
        long hitPointsBonus,
        long damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public long StrengthBonus
    {
        get => this.strengthBonus;
        private set => this.strengthBonus = value;
    }

    public long AgilityBonus
    {
        get => this.agilityBonus;
        private set => this.agilityBonus = value;
    }

    public long IntelligenceBonus
    {
        get => this.intelligenceBonus;
        private set => this.intelligenceBonus = value;
    }

    public long HitPointsBonus
    {
        get => this.hitPointsBonus;
        private set => this.hitPointsBonus = value;
    }

    public long DamageBonus
    {
        get => this.damageBonus;
        private set => this.damageBonus = value;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        
        result.AppendLine($"###Item: {this.Name}"); 
        result.AppendLine($"###+{this.StrengthBonus} Strength"); 
        result.AppendLine($"###+{this.AgilityBonus} Agility"); 
        result.AppendLine($"###+{this.IntelligenceBonus} Intelligence"); 
        result.AppendLine($"###+{this.HitPointsBonus} HitPoints");
        result.Append($"###+{this.DamageBonus} Damage");

        return result.ToString();
    }
}