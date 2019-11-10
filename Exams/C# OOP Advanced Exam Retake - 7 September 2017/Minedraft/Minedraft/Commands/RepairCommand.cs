using System.Collections.Generic;

public class RepairCommand : Command
{
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments, IProviderController providerController)
        : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int repairValue = int.Parse(base.Arguments[0]);

        string result = this.providerController.Repair(repairValue);

        return result;
    }
}