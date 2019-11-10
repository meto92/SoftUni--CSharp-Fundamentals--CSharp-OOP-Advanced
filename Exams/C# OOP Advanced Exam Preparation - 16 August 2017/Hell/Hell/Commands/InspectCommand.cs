using System.Collections.Generic;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IManager manager) 
        : base(arguments, manager)
    { }

    public override string Execute()
    {
        string heroName = base.Arguments[0];

        string result = base.Manager.InspectHero(heroName);

        return result;
    }
}