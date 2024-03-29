﻿using Suls.Services;
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
            if (IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }
            this.SignIn(userId);

            return this.Redirect("/");
        }
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string password, string email, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters.");
            }
            if(string.IsNullOrEmpty(email)|| !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid email address.");
            }
            if(password.Length<6 || password.Length > 20)
            {
                return this.Error("Password must be between 5 and 20 characters.");
            }
            if (password != confirmPassword)
            {
                return this.Error("Passwords don't match");
            }

            this.usersService.CreateUser(username, email, password);
            return this.Redirect("/Users/Login");
        }
    }
}
