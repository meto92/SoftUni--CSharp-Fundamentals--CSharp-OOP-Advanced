using System.Collections.Generic;

public class User
{
    private string name;
    private readonly HashSet<Category> categories;

    public User(string name)
    {
        this.Name = name;
        this.categories = new HashSet<Category>();
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public ISet<Category> Categories => this.categories;

    public void AssignToCategory(Category category)
    {
        category.Users.Add(this);
        this.Categories.Add(category);
    }
}