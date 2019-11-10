public interface IWeaponRepository
{
    void AddWeapon(IWeapon weapon);

    void AddGem(string weaponName, int socketIndex, IGem gem);

    void RemoveSocket(string weaponName, int socketIndex);

    string Print(string weaponName);
}