using System;
using System.Linq;
using System.Reflection;

public class WeaponFactory : IWeaponFactory
{
    private const string InvalidWeaponTypeMessage = "Invalid weapon type: {0}";
    private const string InvalidRarityLevelMessage = "Invalid rarity level: {0}";

    public IWeapon CreateWeapon(string weaponType, string weaponName, string rarityLevelStr)
    {
        Type type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.IsClass && t.GetCustomAttributes()
                .Any(a => a.GetType() == typeof(WeaponAttribute)) &&
                t.Name == weaponType);

        if (type == null)
        {
            throw new NotSupportedException(
                string.Format(InvalidWeaponTypeMessage, weaponType));
        }

        if (!Enum.TryParse(rarityLevelStr, true, out RarityLevel rarityLevel))
        {
            throw new NotSupportedException(
                string.Format(InvalidRarityLevelMessage, rarityLevelStr));
        }

        IWeapon weapon = Activator.CreateInstance(type, weaponName, rarityLevel) as IWeapon;

        return weapon;
    }
}