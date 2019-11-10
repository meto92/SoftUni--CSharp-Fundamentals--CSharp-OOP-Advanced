using System.Linq;
using System.Collections.Generic;

public class SiteController
{
    private ISet<User> users;
    private ISet<Category> categories;

    public SiteController()
    {
        this.users = new HashSet<User>();
        this.categories = new HashSet<Category>();
    }

    public void AddCategory(Category category)
    {
        this.categories.Add(category);
    }

    private void ReassignUsersToChildCategory(Category parentCategory)
    {
        Category child = parentCategory.ChildCategories.FirstOrDefault();

        if (child != null)
        {
            foreach (User user in parentCategory.Users)
            {
                child.Users.Add(user);
            }

            parentCategory.Users.Clear();
        }
    }

    public void RemoveCategory(Category category)
    {
        this.ReassignUsersToChildCategory(category);
        this.categories.Remove(category);
    }

    public void AssignChildCategory(Category parent, Category child)
    {
        parent.AssignChildCategory(child);
    }
}