using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type soldierType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == soldierTypeName &&
                typeof(ISoldier).IsAssignableFrom(t));

        if (soldierType == null)
        {
            throw new ArgumentException(
                string.Format(OutputMessages.UnknownSoldierType, soldierTypeName));
        }

        object[] soldierArgs =
        {
            name,
            age,
            experience,
            endurance
        };

        ISoldier soldier = (ISoldier) Activator.CreateInstance(soldierType, soldierArgs);

        return soldier;
    }
}