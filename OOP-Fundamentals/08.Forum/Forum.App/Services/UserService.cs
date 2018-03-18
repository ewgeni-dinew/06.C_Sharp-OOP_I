using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Forum.App.Controllers.SignUpController;

namespace Forum.App.Services
{
    public static class UserService
    {
        public static bool TryLogInUser(string username,string password)
        {
            if (string.IsNullOrEmpty(username)||string.IsNullOrEmpty(password))
            {
                return false;
            }

            var forumData = new ForumData();
            var usersExist = forumData.Users.Any(u => u.Username.Equals(username) && u.Password.Equals(password));
            return usersExist;
        }

        public static SignUpStatus TrySignUpUser(string username,string password)
        {
            var validUsername = !string.IsNullOrEmpty(username) && username.Length > 3;
            var validPassword = !string.IsNullOrEmpty(password) && password.Length > 3;

            if (!validPassword||!validPassword)
            {
                return SignUpStatus.DetailsError;
            }

            var forumData = new ForumData();
            var userExists = forumData.Users.Any(u=>u.Username.Equals(username));

            if (!userExists)
            {
                var userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                var user = new User(userId,username,password);
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }
            return SignUpStatus.UsernameTakenError;
        }
    }
}
