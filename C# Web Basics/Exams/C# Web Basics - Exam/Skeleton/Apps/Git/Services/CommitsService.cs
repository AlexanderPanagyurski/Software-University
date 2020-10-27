using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string repositoryId, string userId, string description)
        {
            var commit = new Commit
            {
                Description = description,
                RepositoryId = repositoryId,
                CreatorId = userId,
                CreatedOn = DateTime.UtcNow,
            };
            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var commit = this.db.Commits.Find(id);
            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAll(string repositoryId)
        {
            var commits = this.db
                .Commits
                .Where(x => x.RepositoryId == repositoryId)
                .Select(x => new CommitViewModel
                {
                    Repository=x.Repository.Name,
                    Description=x.Description,
                    CreatedOn=x.CreatedOn.ToString("dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture),
                    Id=x.Id
                })
                .ToArray();

            return commits;
        }

        public IEnumerable<UsersCommitsViewModel> GetAllUsersCommits(string userId)
        {

            var userCommitsViewModel = this
                    .db
                    .Commits
                    .Where(x => x.CreatorId == userId)
                    .Select(x => new UsersCommitsViewModel
                    {
                        Repository=x.Repository.Name,
                        Description=x.Description,
                        CreatedOn=x.CreatedOn.ToString("dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture),
                        Id=x.Id
                    })
                    .ToArray();

            return userCommitsViewModel;

        }
    }
}
