using System.Collections.Generic;

public class HeroCommand : Command
{
    [Inject]
    private IHeroFactory heroFactory;

    public HeroCommand(IList<string> arguments, IManager manager)
        : base(arguments, manager)
    { }

    public override string Execute()
    {
        string heroName = base.Arguments[0];
        string heroType = base.Arguments[1];
        
        IHero hero = this.heroFactory.CreateHero(heroName, heroType);

        string result = base.Manager.AddHero(hero);

        return result;
    }
}