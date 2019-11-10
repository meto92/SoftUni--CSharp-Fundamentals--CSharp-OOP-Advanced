using System.Linq;
using System.Collections.Generic;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(
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
        int id = int.Parse(base.Arguments[0]);

        IEntity entity = this.harvesterController.Entities
            .Concat(this.providerController.Entities)
            .FirstOrDefault(e => e.ID == id);

        return entity?.ToString() ?? string.Format(Constants.NoEntityFoundWithGivedId, id);
    }
}