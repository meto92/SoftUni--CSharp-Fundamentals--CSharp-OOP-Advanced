public class GroupAttackCommand : ICommand
{
    private IAttackGroup attackGroup;

    public GroupAttackCommand(IAttackGroup attackGroup)
    {
        this.AttackGroup = attackGroup;
    }

    public IAttackGroup AttackGroup
    {
        get => this.attackGroup;
        private set => this.attackGroup = value;
    }

    public void Execute() => this.AttackGroup.GroupAttack();
}