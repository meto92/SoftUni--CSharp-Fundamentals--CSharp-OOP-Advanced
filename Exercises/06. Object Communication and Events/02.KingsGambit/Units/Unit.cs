public abstract class Unit
{
    private string name;

    protected Unit(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public abstract string MessageOnKingAttacked { get; }
}