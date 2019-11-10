public class PrintCommand : Command
{
    [Inject]
    IWeaponRepository weaponRepository;
    [Inject]
    private IOutputWriter outputWriter;

    public PrintCommand(string[] data)
        : base(data)
    { }

    public override void Execute()
    {
        string weaponName = base.Data[0];

        this.outputWriter.WriteLine(this.weaponRepository.Print(weaponName));
    }
}