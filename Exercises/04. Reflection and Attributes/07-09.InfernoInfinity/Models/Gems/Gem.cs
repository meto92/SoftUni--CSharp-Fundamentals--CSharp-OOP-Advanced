[Gem]
public abstract class Gem : IGem
{
    private int strength;
    private int agility;
    private int vitality;

    protected Gem(
        int strength, 
        int agility, 
        int vitality, 
        GemClarityStatsBonus gemClarityStatsBonus)
    {
        int bonus = (int) gemClarityStatsBonus;

        this.Strength = strength + bonus;
        this.Agility = agility + bonus;
        this.Vitality = vitality + bonus;
    }

    public int Strength
    {
        get => this.strength;
        private set => this.strength = value;
    }

    public int Agility
    {
        get => this.agility;
        private set => this.agility = value;
    }

    public int Vitality
    {
        get => this.vitality;
        private set => this.vitality = value;
    }
}