using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

public class HarvesterFactory : IHarvesterFactory
{
    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];

        int id = int.Parse(args[1]);
        double oreOutput = double.Parse(args[2]);
        double energyReq = double.Parse(args[3]);

        Type harvesterType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + "Harvester");

        if (harvesterType == null)
        {
            throw new ArgumentException(string.Format(Constants.UnknownHarvester, type));
        }

        IHarvester harvester = (IHarvester) Activator.CreateInstance(
            harvesterType, 
            id, oreOutput, energyReq);

        return harvester;
    }
}