using System.Collections.Generic;

public class Group : IAttackGroup
{
    private List<IAttacker> attackers;

    public Group()
    {
        this.attackers = new List<IAttacker>();
    }

    public ICollection<IAttacker> Attakers => this.attackers;

    public void AddMember(IAttacker attacker)
    {
        this.Attakers.Add(attacker);
    }

    public void GroupAttack()
    {
        this.attackers.ForEach(attacker => attacker.Attack());
    }

    public void GroupTarget(IObservableTarget target)
    {
        this.attackers.ForEach(attacker => attacker.SetTarget(target));
    }

    public void GroupTargetAndAttack(IObservableTarget target)
    {
        this.GroupTarget(target);
        this.GroupAttack();
    }
}