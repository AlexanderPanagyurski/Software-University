using Suls.Services;
using Suls.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }


        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (IsUserSignedIn())
            {
                var problems = this.problemsService.GetAll();
                return this.View(problems, "IndexLoggedIn");
            }
            return this.View();
        }
    }
}
