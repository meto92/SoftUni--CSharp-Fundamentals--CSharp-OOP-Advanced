using System;
using System.Linq;
using System.Collections.Generic;

public abstract class Soldier : ISoldier
{
    private const int MaxEndurance = 100;
    private const int AdditionalEnduranceGainedOnRegeneration = 10;

    private double endurance;
    private double overallSkillMultiplier;

    protected Soldier(
        string name, 
        int age, 
        double experience, 
        double endurance, 
        double overallSkillMultiplier)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.overallSkillMultiplier = overallSkillMultiplier;
        this.Weapons = this.WeaponsAllowed
            .ToDictionary(weaponType => weaponType, value => (IAmmunition) null);
    }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        protected set => this.endurance = Math.Min(value, MaxEndurance);
    }

    public IDictionary<string, IAmmunition> Weapons { get; }
    
    public double OverallSkill => this.overallSkillMultiplier * (this.Age + this.Experience);

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }
        
        bool hasAllEquipment = this.Weapons.Values.All(weapon => weapon != null);

        if (!hasAllEquipment)
        {
            return false;
        }

        bool areAllWeaponsUsable = this.Weapons.Values.All(weapon => weapon.WearLevel > 0);

        return areAllWeaponsUsable;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();

        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public virtual void Regenerate()
    {
        this.Endurance += AdditionalEnduranceGainedOnRegeneration + this.Age;
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;

        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    public override string ToString()
    {
        return string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
    }
}