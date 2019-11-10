public interface IWeapon
{
    string Name { get; }

    int MinDamage { get; }

    int MaxDamage { get; }

    int SocketsCount { get; }

    RarityLevel RarityLevel { get; }

    void AddGem(int socketIndex, IGem gem);

    void RemoveGem(int socketIndex);
}