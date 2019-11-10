public abstract class Unit
{
    private string name;
    private int hitsToTake;

    protected Unit(string name, int hitsToTake)
    {
        this.Name = name;
        this.HitsToTake = hitsToTake;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }
    
    public int HitsToTake
    {
        get => this.hitsToTake;
        private set => this.hitsToTake = value;
    }
    
    public void TakeHit()
    {
        this.HitsToTake--;
    }

    public bool IsDead => this.HitsToTake <= 0;

    public abstract string MessageOnKingAttacked { get; }
}