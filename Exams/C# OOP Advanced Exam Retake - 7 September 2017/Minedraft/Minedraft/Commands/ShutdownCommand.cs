using System.Text;
using System.Collections.Generic;

public class ShutdownCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public ShutdownCommand(
        IList<string> arguments, 
        IProviderController providerController, 
        IHarvesterController harvesterController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine(Constants.SystemShutdown);
        result.AppendLine(string.Format(
            Constants.TotalEnergyProduced, 
            this.providerController.TotalEnergyProduced));
        result.Append(string.Format(
            Constants.TotalMinedOre,
            this.harvesterController.OreProduced));

        return result.ToString();
    }
}