using System;
using System.Linq;
using System.Collections.Generic;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory ammunitionFactory;
    private IDictionary<string, int> countByAmmunitionType;

    public WareHouse()
        : this(new AmmunitionFactory())
    { }

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.countByAmmunitionType = new Dictionary<string, int>();
    }

    public void AddAmmunitions(string ammunitionType, int count)
    {
        Type type = Type.GetType(ammunitionType);

        if (type == null || !typeof(IAmmunition).IsAssignableFrom(type))
        {
            throw new ArgumentException(
                string.Format(OutputMessages.UnknownAmmunitionType, ammunitionType));
        }

        if (!this.countByAmmunitionType.ContainsKey(ammunitionType))
        {
            this.countByAmmunitionType[ammunitionType] = 0;
        }
        
        this.countByAmmunitionType[ammunitionType] += count;
    }

    private bool HasAmmunition(string weaponType)
    {
        if (this.countByAmmunitionType.TryGetValue(weaponType, out int count))
        {
            return count > 0;
        }

        return false;
    }

    private string[] GetSoldierRequiredWeaponTypes(ISoldier soldier)
    {
        return soldier.Weapons
            .Where(w => w.Value == null)
            .Select(pair => pair.Key)
            .ToArray();
    }

    private void GiveAmmunitionToSoldier(ISoldier soldier, string weaponType)
    {
        soldier.Weapons[weaponType] = this.ammunitionFactory.CreateAmmunition(weaponType);
        this.countByAmmunitionType[weaponType]--;
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isEquipped = true;

        string[] requiredWeapons = GetSoldierRequiredWeaponTypes(soldier);

        foreach (string weaponType in requiredWeapons)
        {
            if (this.HasAmmunition(weaponType))
            {
                this.GiveAmmunitionToSoldier(soldier, weaponType);
            }
            else
            {
                isEquipped = false;
            }
        }

        return isEquipped;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }
}