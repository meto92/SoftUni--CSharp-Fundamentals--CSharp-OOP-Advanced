using System.Linq;
using System.Reflection;

public class ReviewersCommand : Command
{
    [Inject]
    private IOutputWriter outputWriter;

    public ReviewersCommand(string[] data)
        : base(data)
    { }

    public override void Execute()
    {
        CustomClassAttribute customAttribute = (CustomClassAttribute) typeof(Weapon)
            .GetCustomAttributes(typeof(CustomClassAttribute))
            .First();

        this.outputWriter.WriteLine($"Reviewers: {string.Join(", ", customAttribute.Reviewers)}");
    }
}