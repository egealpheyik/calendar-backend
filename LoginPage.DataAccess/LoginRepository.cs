using LoginPage.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginPage.DataAccess
{
    public class LoginRepository
    {
        private LoginPageDbContext DbContext;
        //private DbSet<User> Dbset;

        
        public List<User> GetUsers() {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                return LoginPageDbContext.Users.ToList();
            }
        }

        public User GetUser(string username, string password)
        {
            using(var LoginPageDbContext = new LoginPageDbContext())
            {
                 LoginPageDbContext.Users.ToList();
            }
            return new User();
            

            //return LoginPageDbContext.Users.FirstOrDefault(x=>x.UserName == username && x.Password == password);
        }
        public User CreateUser(User user) //id kendiliğinden artmalı
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                LoginPageDbContext.Users.Add(user);
                LoginPageDbContext.SaveChanges();

            }
                
            //LoginPageDbContext.Users.Add(user);
            return user;
        }

        public User FindUser(string username, string password)
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                User u =  LoginPageDbContext.Users.FirstOrDefault(x=>x.UserName == username && x.Password == password);
                if(u == null)
                {
                    return new User();
                }
                return u;
            }
                
        }
        public User FindUserByUsername(string username)
        {
            using(var LoginPageDbContext = new LoginPageDbContext())
            {
                try { User FoundUser = LoginPageDbContext.Users.FirstOrDefault(x => x.UserName == username);
                    return FoundUser; }
                catch(Exception e)
                {
                    return null;
                }
            }
        }
        public User UpdateUserPassword(User user, string newPassword)
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                user.Password = newPassword;
                LoginPageDbContext.Users.Update(user);
                LoginPageDbContext.SaveChanges();
                return user;
            }
        }
        public User DeleteUser(string username, string password)
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                User deleteUser = FindUser(username, password);
                LoginPageDbContext.Users.Remove(deleteUser);
                LoginPageDbContext.SaveChanges();
                return deleteUser;
            }
            
        }

    }
}
