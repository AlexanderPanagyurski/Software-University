using Suls.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Suls.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userdId = this.usersService.GetUserId(username, password);
            if (userdId == null)
            {
                return this.Error("Invalid username or password.");
            }
            this.SignIn(userdId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 20)
            {
                return this.Error("Invalid username. Username must be between 5 and 20 symbols.");
            }
            if (string.IsNullOrEmpty(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid email address.");
            }
            if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 20)
            {
                return this.Error("Invalid password. Password must be between 6 and 20 symbols.");
            }
            if (password != confirmPassword)
            {
                return this.Error("Passwords should be the same.");
            }
            this.usersService.CreateUser(username, email, password);
            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
