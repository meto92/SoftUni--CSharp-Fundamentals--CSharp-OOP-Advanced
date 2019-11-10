using System.Linq;
using System.Reflection;

public class DescriptionCommand : Command
{
    [Inject]
    IWeaponRepository weaponRepository;
    [Inject]
    private IOutputWriter outputWriter;

    public DescriptionCommand(string[] data)
        : base(data)
    { }

    public override void Execute()
    {
        CustomClassAttribute customAttribute = (CustomClassAttribute) typeof(Weapon)
            .GetCustomAttributes(typeof(CustomClassAttribute))
            .First();

        this.outputWriter.WriteLine($"Class description: {customAttribute.Description}");
    }
}