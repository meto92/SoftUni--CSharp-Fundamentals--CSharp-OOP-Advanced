public class CreateCommand : Command
{
    [Inject]
    IWeaponRepository weaponRepository;
    [Inject]
    private IWeaponFactory weaponFactory;

    public CreateCommand(string[] data)
        : base(data)
    { }

    public override void Execute()
    {
        string[] weaponRarirytyAndType = base.Data[0].Split();

        string weaponRarity = weaponRarirytyAndType[0];
        string weaponType = weaponRarirytyAndType[1];
        string weaponName = base.Data[1];

        IWeapon weapon = this.weaponFactory.CreateWeapon(weaponType, weaponName, weaponRarity);

        this.weaponRepository.AddWeapon(weapon);
    }
}