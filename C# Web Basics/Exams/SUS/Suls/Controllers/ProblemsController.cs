﻿using Suls.Services;
using Suls.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }
        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.View("Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (!this.IsUserSignedIn())
            {
                return this.View("Users/Login");
            }
            if (string.IsNullOrEmpty(name) || name.Length < 5 || name.Length > 20)
            {
                return this.Error("Invalid Problem's name. Name must be between 5 and 20 characters.");
            }
            if (points < 50 || points > 300)
            {
                return this.Error("Problem's points must be between 50 and 300.");
            }
            this.problemsService.Create(name, points);
            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.View("Users/Login");
            }
            var viewModel = this.problemsService.GetById(id);
            return this.View(viewModel);
        }
    }
}
