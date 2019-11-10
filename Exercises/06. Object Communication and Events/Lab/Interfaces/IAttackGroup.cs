public interface IAttackGroup
{
    void AddMember(IAttacker attacker);

    void GroupTarget(IObservableTarget target);

    void GroupAttack();
}