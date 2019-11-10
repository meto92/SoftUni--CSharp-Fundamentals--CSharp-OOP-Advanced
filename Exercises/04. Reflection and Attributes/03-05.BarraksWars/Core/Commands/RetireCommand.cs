public class RetireCommand : Command
{
    [Inject]
    private IRepository repository;

    public RetireCommand(string[] data) 
        : base(data)
    { }

    public override string Execute()
    {
        string unitType = base.Data[0];

        this.repository.RemoveUnit(unitType);

        return $"{unitType} retired!";
    }
}