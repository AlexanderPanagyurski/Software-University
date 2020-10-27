using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoryService repositoryService;

        public CommitsController(ICommitsService commitsService, IRepositoryService repositoryService)
        {
            this.commitsService = commitsService;
            this.repositoryService = repositoryService;
        }

        public HttpResponse Create(string id)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var viewModel = new CreatCommitViewModel
            {
                Id = id,
                Name = this.repositoryService.GetNameById(id),
                RepositoryId=id
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string repositoryId, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (string.IsNullOrEmpty(description) || description.Length < 5)
            {
                return this.Error("Description should be above 5 characters.");
            }
            var userId = this.GetUserId();
            this.commitsService.Create(repositoryId, userId, description);
            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            var viewModel = this.commitsService.GetAllUsersCommits(userId);

            return this.View(viewModel);
        }

        public HttpResponse Delete(string id)
        {
            this.commitsService.Delete(id);

            return this.Redirect("/Commits/All");
        }
    }
}
