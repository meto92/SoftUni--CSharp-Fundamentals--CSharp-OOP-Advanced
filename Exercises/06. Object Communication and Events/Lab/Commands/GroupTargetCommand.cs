public class GroupTargetCommand : ICommand
{
    private IAttackGroup attackGroup;
    private IObservableTarget target;

    public GroupTargetCommand(IAttackGroup attackGroup, IObservableTarget target)
    {
        this.AttackGroup = attackGroup;
        this.Target = target;
    }

    public IAttackGroup AttackGroup
    {
        get => this.attackGroup;
        private set => this.attackGroup = value;
    }

    public IObservableTarget Target
    {
        get => this.target;
        private set => this.target = value;
    }

    public void Execute() => this.AttackGroup.GroupTarget(this.Target);
}