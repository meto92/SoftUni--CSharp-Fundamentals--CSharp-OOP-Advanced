using System;
using System.Linq;
using System.Collections.Generic;

using Forum.App.Contracts;
using Forum.App.ViewModels;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        private Category EnsureCategory(string postCategory)
        {
            Category category = this.forumData.Categories
                .Find(c => c.Name == postCategory);

            if (category == null)
            {
                int categoryId = this.forumData.Categories.Count + 1;

                category = new Category(categoryId, postCategory, new int[0]);

                this.forumData.Categories.Add(category);
                this.forumData.SaveChanges();
            }

            return category;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            Func<string, bool> isEmpty = str => string.IsNullOrWhiteSpace(str);

            bool isTitleEmpty = isEmpty(postTitle);
            bool isCategoryEmpty = isEmpty(postCategory);
            bool isContentEmpty = isEmpty(postContent);

            if (isTitleEmpty || isCategoryEmpty || isContentEmpty)
            {
                throw new ArgumentException("All fields must be field!");
            }

            Category category = this.EnsureCategory(postCategory);

            int postId = this.forumData.Posts.Count + 1;

            User author = this.userService.GetUserById(userId);

            Post post = 
                new Post(postId, postTitle, postContent, category.Id, author.Id, new int[0]);

            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            this.forumData.Posts.Add(post);
            this.forumData.SaveChanges();

            return post.Id;
        }
        
        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            if (string.IsNullOrWhiteSpace(replyContents))
            {
                throw new ArgumentException();
            }

            Post post = this.forumData
                .Posts
                .First(p => p.Id == postId);

            int replyId = this.forumData.Replies.Count + 1;

            Reply reply = new Reply(replyId, replyContents, userId, post.Id);
            
            post.Replies.Add(replyId);
            this.forumData.Replies.Add(reply);
            this.forumData.SaveChanges();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories = this.forumData
                .Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData
                .Categories
                .Find(c => c.Id == categoryId)
                ?.Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return categoryName;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            IEnumerable<IPostInfoViewModel> posts = this.forumData
                .Posts
                .Where(c => c.CategoryId == categoryId)
                .Select(c => new PostInfoViewModel(c.Id, c.Title, c.Replies.Count));

            return posts;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            IEnumerable<IReplyViewModel> replies = this.forumData.Replies
                .Where(r => r.PostId == postId)
                .Select(r => new ReplyViewModel(
                    this.userService.GetUserName(r.AuthorId), 
                    r.Content));

            return replies;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            Post post = this.forumData.Posts
                .First(p => p.Id == postId);

            string author = this.userService.GetUserById(post.AuthorId).Username;
            IEnumerable<IReplyViewModel> replies = this.GetPostReplies(postId);

            IPostViewModel postViewModel = new PostViewModel(post.Title, author, post.Content, replies);

            return postViewModel;
        }
    }
}