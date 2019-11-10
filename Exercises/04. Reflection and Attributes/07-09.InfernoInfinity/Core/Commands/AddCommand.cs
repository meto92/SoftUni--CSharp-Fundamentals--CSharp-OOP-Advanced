public class AddCommand : Command
{
    [Inject]
    IWeaponRepository weaponRepository;
    [Inject]
    private IGemFactory gemFactory;

    public AddCommand(string[] data)
        : base(data)
    { }

    public override void Execute()
    {
        string weaponName = base.Data[0];
        int socketIndex = int.Parse(Data[1]);
        string[] gemParams = base.Data[2].Split();
        string gemClarity = gemParams[0];
        string gemType = gemParams[1];

        IGem gem = this.gemFactory.CreateGem(gemType, gemClarity);

        this.weaponRepository.AddGem(weaponName, socketIndex, gem);
    }
}