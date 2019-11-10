public class RemoveCommand : Command
{
    [Inject]
    IWeaponRepository weaponRepository;

    public RemoveCommand(string[] data)
        : base(data)
    { }

    public override void Execute()
    {
        string weaponName = base.Data[0];
        int socketIndex = int.Parse(base.Data[1]);

        this.weaponRepository.RemoveSocket(weaponName, socketIndex);
    }
}