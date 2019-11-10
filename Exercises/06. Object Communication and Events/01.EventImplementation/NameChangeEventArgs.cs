using System;

public class NameChangeEventArgs : EventArgs
{
    private string name;

    public NameChangeEventArgs(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }
}