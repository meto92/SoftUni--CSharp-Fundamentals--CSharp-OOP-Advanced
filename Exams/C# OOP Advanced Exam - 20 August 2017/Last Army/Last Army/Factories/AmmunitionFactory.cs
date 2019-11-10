using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammunitionType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == ammunitionName &&
                typeof(IAmmunition).IsAssignableFrom(t));

        if (ammunitionType == null)
        {
            throw new ArgumentException(
                string.Format(OutputMessages.UnknownAmmunitionType, ammunitionName));
        }

        IAmmunition ammunition = (IAmmunition) Activator.CreateInstance(ammunitionType);

        return ammunition;
    }
}