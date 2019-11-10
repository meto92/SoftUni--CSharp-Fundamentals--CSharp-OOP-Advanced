using System.Collections.Generic;

public class QuitCommand : Command
{
    public QuitCommand(IList<string> arguments, IManager manager) 
        : base(arguments, manager)
    { }

    public override string Execute()
    {
        string result = base.Manager.GetHeroesInfo();

        return result;
    }
}