using System;
using System.Linq;
using System.Reflection;

public class GemFactory : IGemFactory
{
    private const string UnknownGemTypeMessage = "Unknown gem type: {0}";
    private const string UnknownClarityMessage = "Unknown clarity: {0}";

    public IGem CreateGem(string gemType, string gemClarity)
    {
        Type type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.GetCustomAttributes()
                .Any(a => a.GetType() == typeof(GemAttribute)) &&
                t.Name == gemType);

        if (type == null)
        {
            throw new NotSupportedException(
                string.Format(UnknownGemTypeMessage, gemType));
        }

        if (!Enum.TryParse(gemClarity, true, out GemClarityStatsBonus gemClarityBonus))
        {
            throw new NotSupportedException(
                string.Format(UnknownClarityMessage, gemClarity));
        }

        IGem gem = Activator.CreateInstance(type, gemClarityBonus) as IGem;

        return gem;
    }
}