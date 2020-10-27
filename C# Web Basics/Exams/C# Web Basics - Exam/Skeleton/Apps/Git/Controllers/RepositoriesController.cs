using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var repositories = this.repositoryService.GetAll();
            return this.View(repositories);
        }

        public HttpResponse Create()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }


        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = GetUserId();
            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 10)
            {
                return this.Error("Invalid repository's name. Name should be between 3 and 10 characters.");
            }
            if(string.IsNullOrEmpty(repositoryType) || (repositoryType != "Public" && repositoryType != "Private"))
            {
                return this.Error("Invalid repository's type. Type should be Public or Private.");
            }
            this.repositoryService.Create(userId, name, repositoryType);

            return this.Redirect("/Repositories/All");
        }
    }
}
