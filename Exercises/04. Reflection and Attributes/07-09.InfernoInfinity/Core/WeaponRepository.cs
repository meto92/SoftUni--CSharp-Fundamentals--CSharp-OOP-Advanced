using System.Collections.Generic;

public class WeaponRepository : IWeaponRepository
{
    private readonly IDictionary<string, IWeapon> weaponByName;

    public WeaponRepository(IDictionary<string, IWeapon> weaponByName)
    {
        this.weaponByName = weaponByName;
    }

    public void AddWeapon(IWeapon weapon) => this.weaponByName[weapon.Name] = weapon;

    public void AddGem(string weaponName, int socketIndex, IGem gem)
    {
        this.weaponByName[weaponName].AddGem(socketIndex, gem);
    }

    public string Print(string weaponName) => this.weaponByName[weaponName].ToString();

    public void RemoveSocket(string weaponName, int socketIndex)
    {
        this.weaponByName[weaponName].RemoveGem(socketIndex);
    }    
}