using System;
using System.Collections.Generic;
using System.Text;
using LoginPage.DataAccess;
using LoginPage.Entities;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Linq;

namespace LoginPage.Business
{

    public class LoginPageManager
    {
        private LoginRepository _manager;
        public LoginPageManager()
        {
            _manager = new LoginRepository();
        }

        public List<User> GetUsers()
        {
            return _manager.GetUsers();
        }

        public User GetUser(string username, string password)
        {
            return _manager.GetUser(username, password);
        }
        public User CreateUser(User user) //
        {
            if(_manager.FindUserByUsername(user.UserName) == null)
            {
                return _manager.CreateUser(user);
            }
            return null;
        }
        public User Login(string username, string password) {
            
            int id = _manager.FindUser(username, password).UserId;
            User u = new User();
            u.UserId = id;
            return u;

        }
        public User DeleteUser(string username, string password)
        {

            return _manager.DeleteUser(username, password);
        }
        public User ChangePassword(string username, string password)
        {
            User user = _manager.FindUserByUsername(username);
            if (user == null)
            {
                User u = new User();
                u.UserId = -1;
                return u;
            }
            user = _manager.UpdateUserPassword(user, password);
            return user;
        }

    }
}
