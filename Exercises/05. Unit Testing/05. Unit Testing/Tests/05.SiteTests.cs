using System;

using NUnit.Framework;

public class SiteTests
{
    private User user;
    private const string Username = "username";
    private Category category;
    private const string CategoryName = "category";
    private Category category2;
    private const string Category2Name = "category2";
    private Category category3;
    private const string Category3Name = "category3";

    [SetUp]
    public void InitTests()
    {
        this.user = new User(Username);
        this.category = new Category(CategoryName);
        this.category2 = new Category(Category2Name);
        this.category3 = new Category(Category3Name);
    }

    [Test]
    public void AssignUserToCategoryShouldAddUserToCategory()
    {
        this.user.AssignToCategory(this.category);

        Assert.AreEqual(true, this.category.Users.Contains(this.user),
            "User not added to category.");
    }

    [Test]
    public void AssignUserToCategoryShouldAddCategoryToUserCategories()
    {
        this.user.AssignToCategory(this.category);

        Assert.AreEqual(true, this.user.Categories.Contains(this.category),
            "Category not added to user categories.");
    }
    
    [Test]
    public void AssignChildCategoryToItselfShouldThrowException()
    {
        Assert.Throws<InvalidOperationException>(
            () => this.category.AssignChildCategory(this.category),
            "Assigning self as child didn't throw exception.");
    }

    [Test]
    public void AssignChildCategoryShouldSetParent()
    {
        this.category.AssignChildCategory(this.category2);

        Assert.AreEqual(true, this.category2.ParentCategory == this.category,
            "Parent ccategory not assigned correctly.");
    }

    [Test]
    public void AssignChildCategoryToAnotherParentShouldRemoveChildFromPrevParent()
    {
        this.category.AssignChildCategory(this.category3);
        this.category2.AssignChildCategory(this.category3);

        Assert.That(this.category.ChildCategories.Contains(this.category3),
            Is.EqualTo(false),
            "Assigning child category to new parent didn't remove child from previous parent.");
    }

    [Test]
    public void RemoveParentCategoryShouldMoveUsersFromParentToChildCategory()
    {
        User user2 = new User("user2");
        SiteController siteController = new SiteController();

        this.user.AssignToCategory(this.category);
        user2.AssignToCategory(this.category);
        this.category.AssignChildCategory(this.category2);
        siteController.RemoveCategory(category);

        CollectionAssert.AreEqual(new User[] { this.user, user2 },
            this.category2.Users,
            "Users from parent category weren't assigned to child category.");
    }

    [Test]
    public void SiteControllerAssignChildCategoryShouldSetParent()
    {
        SiteController siteController = new SiteController();

        siteController.AssignChildCategory(this.category, this.category2);

        Assert.AreEqual(true, this.category2.ParentCategory == this.category,
            "Parent ccategory not assigned correctly.");
    }
}