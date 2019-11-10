using System;
using System.Linq;
using System.Collections.Generic;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(
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
        IList<string> args = base.Arguments.Skip(1).ToList();

        switch (base.Arguments[0])
        {
            case nameof(Harvester):
                return this.harvesterController.Register(args);
            case nameof(Provider):
                return this.providerController.Register(args);
            default:
                throw new ArgumentException();
        }
    }
}