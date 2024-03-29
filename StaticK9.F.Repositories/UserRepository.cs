﻿using StaticK9.F.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaticK9.F.Security;

namespace StaticK9.F.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User { Id = 3522, Name = "roland", Password = "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=",
                FavoriteColor = "blue", Role = "Admin", GoogleId = "101517359495305583936" }
        };

        public User GetByGoogleId(string googleId)
        {
            var user = users.SingleOrDefault(u => u.GoogleId == googleId);
            return user;
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            var passwordx = password.Sha256();
            var user = users.SingleOrDefault(u => u.Name == username &&
              u.Password == password.Sha256());
            return user;
        }
    }
}
