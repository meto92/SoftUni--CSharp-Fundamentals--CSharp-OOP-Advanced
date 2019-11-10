using System;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class SoftUniAttribute : Attribute
{
    private string name;

    public SoftUniAttribute(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }
}