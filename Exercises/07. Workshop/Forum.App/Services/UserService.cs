using System;
using System.Linq;

using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
    public class UserService : IUserService
    {
        private const string UserWithGivenIdNotFound = "User with id {0} not found!";

        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public User GetUserById(int userId)
        {
            User user = this.forumData.Users
                .Find(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException(
                    string.Format(UserWithGivenIdNotFound, userId));
            }

            return user;
        }

        public string GetUserName(int userId)
        {
            User user = this.forumData.Users
                .Find(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException(
                    string.Format(UserWithGivenIdNotFound, userId));
            }

            return user.Username;
        }

        public bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            User user = this.forumData.Users
                .Find(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return false;
            }

            session.Reset();
            this.session.LogIn(user);

            return true;
        }

        public bool TrySignUpUser(string username, string password)
        {
            Func<string, bool> isValid = str =>
                !string.IsNullOrWhiteSpace(str) && str.Length > 3;

            bool isUsernameValid = isValid(username);
            bool isPasswordValid = isValid(password);

            if (!isUsernameValid || !isPasswordValid)
            {
                throw new ArgumentException("Username and password must be longer than 3 symbols!");
            }

            bool usernameAlreadyExists = this.forumData.Users.Any(u => u.Username == username);

            if (usernameAlreadyExists)
            {
                throw new InvalidOperationException("Username taken!");
            }

            int userId = this.forumData.Users.Count + 1;
            User user = new User(userId, username, password);

            this.forumData.Users.Add(user);
            this.forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }
    }
}