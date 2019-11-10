using static Startup;

public class Dispatcher
{
    private string name;
    public event NameChangeEventHandler NameChange;

    public string Name
    {
        get => this.name;

        set
        {
            this.name = value;
            this.OnNameChange(new NameChangeEventArgs(value));
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        this.NameChange(this, args);
    }
}