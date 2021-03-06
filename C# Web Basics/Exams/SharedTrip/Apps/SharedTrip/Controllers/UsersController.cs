﻿using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Controllers
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
            var userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }
            this.SignIn(userId);
            return this.Redirect("/Trips/All");
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
                return this.Error("Invalid username. Username should be between 5 and 20 characters.");
            }
            if (!this.usersService.IsUsernameAvailable(username))
            {
                return this.Error("Username is already used.");
            }
            if (string.IsNullOrEmpty(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid email address. Email is required.");
            }
            if (!this.usersService.IsEmailAvailable(email))
            {
                return this.Error("Email address is already used.");
            }
            if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 20)
            {
                return this.Error("Invalid password. Password should be between 6 and 20 characters.");
            }
            if (password != confirmPassword)
            {
                return this.Error("Passwords don't match.");
            }
            this.usersService.CreateUser(username, email, password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!IsUserSignedIn())
            {
                return this.Error("You are not logged-in");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
