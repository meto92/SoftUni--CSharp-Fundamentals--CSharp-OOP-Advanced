public class AttackCommand : ICommand
{
    private IAttacker attacker;
    
    public AttackCommand(IAttacker attacker)
    {
        this.Attacker = attacker;        
    }

    public IAttacker Attacker
    {
        get => this.attacker;
        private set => this.attacker = value;
    }

    public void Execute()
    {
        this.Attacker.Attack();
    }
}