using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginPage.Business;
using LoginPage.Entities;

namespace LoginPage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        private LoginPageManager _loginRegisterManager;
        public LoginRegisterController()

        {
            _loginRegisterManager = new LoginPageManager();
        }
        [HttpGet]
        public List<User> Get()
        {
            return _loginRegisterManager.GetUsers();
        }
        [HttpPost]
        public User CreateUser([FromBody]User user)
        {
            return _loginRegisterManager.CreateUser(user);
            
        }
        [HttpPost("login")]
        public User Login(User user)
        {
            return _loginRegisterManager.Login(user.UserName, user.Password);
        }
        [HttpDelete("removeuser")]
        public User RemoveUser(User user)
        {
            return _loginRegisterManager.DeleteUser(user.UserName, user.Password);
        }
        [HttpPatch("login")]
        public User ChangePassword(User user)
        {
            return _loginRegisterManager.ChangePassword(user.UserName, user.Password);
            
        }

    }
}