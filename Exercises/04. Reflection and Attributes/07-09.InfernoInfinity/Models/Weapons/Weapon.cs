using System;
using System.Linq;

[Weapon]
[CustomClass(
    "Pesho",
    3,
    "Used for C# OOP Advanced Course - Enumerations and Attributes.",
    "Pesho", "Svetlio")]
public abstract class Weapon : IWeapon
{
    private string name;
    private int minDamage;
    private int maxDamage;
    private int socketsCount;
    private readonly IGem[] gems;
    private RarityLevel rarityLevel;

    protected Weapon(
        string name, 
        int minDamage, 
        int maxDamage, 
        int socketsCount, 
        RarityLevel rarityLevel)
    {
        this.Name = name;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.SocketsCount = socketsCount;
        this.RarityLevel = rarityLevel;
        this.gems = (IGem[]) Array.CreateInstance(typeof(Gem), this.SocketsCount);
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int MinDamage
    {
        get => this.minDamage * (int) this.RarityLevel;
        private set => this.minDamage = value;
    }

    public int MaxDamage
    {
        get => this.maxDamage * (int) this.RarityLevel;
        private set => this.maxDamage = value;
    }

    public int SocketsCount
    {
        get => this.socketsCount;
        private set => this.socketsCount = value;
    }

    public RarityLevel RarityLevel
    {
        get => this.rarityLevel;
        private set => this.rarityLevel = value;
    }

    private bool IsValidSocketIndex(int socketIndex) =>
        socketIndex >= 0 && socketIndex < this.SocketsCount;

    public void AddGem(int socketIndex, IGem gem)
    {
        if (this.IsValidSocketIndex(socketIndex))
        {
            this.gems[socketIndex] = gem;
        }
    }

    public void RemoveGem(int socketIndex)
    {
        if (this.IsValidSocketIndex(socketIndex))
        {
            this.gems[socketIndex] = null;
        }
    }

    public override string ToString()
    {
        int strength = 0,
            agility = 0,
            vitality = 0;

        foreach (IGem gem in this.gems.Where(g => g != null))
        {
            strength += gem.Strength;
            agility += gem.Agility;
            vitality += gem.Vitality;
        }

        int finalMinDamage = this.MinDamage + 2 * strength + agility;
        int finalMaxDamage = this.MaxDamage + 3 * strength + 4 * agility;

        string result = string.Format(
            "{0}: {1}-{2} Damage, +{3} Strength, +{4} Agility, +{5} Vitality",
            this.Name,
            finalMinDamage,
            finalMaxDamage,
            strength,
            agility,
            vitality);

        return result;
    }
}