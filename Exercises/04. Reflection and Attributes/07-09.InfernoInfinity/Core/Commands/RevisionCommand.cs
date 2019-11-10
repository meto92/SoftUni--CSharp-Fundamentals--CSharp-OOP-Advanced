using System.Linq;
using System.Reflection;

public class RevisionCommand : Command
{
    [Inject]
    private IOutputWriter outputWriter;

    public RevisionCommand(string[] data)
        : base(data)
    { }

    public override void Execute()
    {
        CustomClassAttribute customAttribute = (CustomClassAttribute) typeof(Weapon)
            .GetCustomAttributes(typeof(CustomClassAttribute))
            .First();

        this.outputWriter.WriteLine($"Revision: {customAttribute.Revision}");
    }
}