public class TargetCommand : ICommand
{
    private IAttacker attacker;
    private IObservableTarget target;

    public TargetCommand(IAttacker attacker, IObservableTarget target)
    {
        this.Attacker = attacker;
        this.Target = target;
    }

    public IAttacker Attacker
    {
        get => this.attacker;
        private set => this.attacker = value;
    }

    public IObservableTarget Target
    {
        get => this.target;
        private set => this.target = value;
    }

    public void Execute()
    {
        this.Attacker.SetTarget(this.Target);
    }
}