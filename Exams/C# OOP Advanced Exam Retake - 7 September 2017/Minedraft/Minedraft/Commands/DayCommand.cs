using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(
        IList<string> arguments,
        IHarvesterController harvesterController,
        IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        return string.Format("{0}{1}{2}",
            this.providerController.Produce(),
            Environment.NewLine,
            this.harvesterController.Produce());
    }
}