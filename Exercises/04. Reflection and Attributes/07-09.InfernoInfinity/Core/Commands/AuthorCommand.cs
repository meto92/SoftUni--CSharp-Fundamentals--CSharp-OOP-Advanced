using System.Linq;
using System.Reflection;

public class AuthorCommand : Command
{
    [Inject]
    private IOutputWriter outputWriter;

    public AuthorCommand(string[] data)
        : base(data)
    { }

    public override void Execute()
    {
        CustomClassAttribute customAttribute = (CustomClassAttribute) typeof(Weapon)
            .GetCustomAttributes(typeof(CustomClassAttribute))
            .First();

        this.outputWriter.WriteLine($"Author: {customAttribute.Author}");
    }
}