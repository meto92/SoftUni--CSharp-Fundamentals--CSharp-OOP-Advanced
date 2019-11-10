using System;
using System.Linq;
using System.Reflection;

public class HeroFactory : IHeroFactory
{
    public IHero CreateHero(string name, string type)
    {
        Type heroType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type &&
                typeof(IHero).IsAssignableFrom(t));

        if (heroType == null)
        {
            throw new ArgumentException(string.Format(
                Constants.UnknownHeroType,
                type));
        }

        IHero hero = (IHero) Activator.CreateInstance(heroType, new object[] { name });

        return hero;
    }
}