using System;

public class Startup
{
    static void Main(string[] args)
    {
        Logger combatLog = new CombatLogger();
        Logger eventLog = new EventLogger();

        combatLog.SetSuccessor(eventLog);

        AbstractHero warrior = new Warrior("1", 10, combatLog);
        AbstractHero warrior2 = new Warrior("2", 20, combatLog);
        IObservableTarget dragon = new Dragon("3", 30, 25, combatLog);
        
        IAttackGroup group = new Group();

        group.AddMember(warrior);
        group.AddMember(warrior2);
        dragon.Register(warrior);
        dragon.Register(warrior2);

        IExecutor executor = new CommandExecutor();

        ICommand groupTarget = new GroupTargetCommand(group, dragon);
        ICommand groupAttack = new GroupAttackCommand(group);
        
        executor.ExecuteCommand(groupTarget);
        executor.ExecuteCommand(groupAttack);

        Console.WriteLine(warrior.Rewards);
        Console.WriteLine(warrior2.Rewards);
    }
}