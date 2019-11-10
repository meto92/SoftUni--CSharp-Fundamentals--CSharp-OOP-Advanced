using System;

[AttributeUsage(AttributeTargets.Class)]
public class CustomClassAttribute : Attribute
{
    private string author;
    private int revision;
    private string description;
    private string[] reviewers;

    public CustomClassAttribute(
        string author, 
        int revision, 
        string description, 
        params string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = reviewers;
    }

    public string Author
    {
        get => this.author;
        private set => this.author = value;
    }

    public int Revision
    {
        get => this.revision;
        private set => this.revision = value;
    }

    public string Description
    {
        get => this.description;
        private set => this.description = value;
    }

    public string[] Reviewers
    {
        get => this.reviewers;
        private set => this.reviewers = value;
    }
}