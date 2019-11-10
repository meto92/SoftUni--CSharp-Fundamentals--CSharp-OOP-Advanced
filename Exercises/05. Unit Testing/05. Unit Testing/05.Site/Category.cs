using System;
using System.Linq;
using System.Collections.Generic;

public class Category
{
    private string name;
    private Category parentCategory;
    private readonly HashSet<User> users;
    private HashSet<Category> childCategories;

    public Category(string name)
    {
        this.Name = name;
        this.users = new HashSet<User>();
        this.childCategories = new HashSet<Category>();
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public ISet<User> Users => this.users;    

    public ISet<Category> ChildCategories => this.childCategories;

    public Category ParentCategory => this.parentCategory;

    public void AssignChildCategory(Category childCategory)
    {
        if (this == childCategory)
        {
            throw new InvalidOperationException();
        }

        if (childCategory.ParentCategory != null)
        {
            childCategory.ParentCategory
                .ChildCategories
                .Remove(childCategory);
        }

        childCategory.parentCategory = this;
        this.ChildCategories.Add(childCategory);
    }
}