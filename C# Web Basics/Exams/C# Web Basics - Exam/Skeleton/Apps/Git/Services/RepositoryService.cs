using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext db;

        public RepositoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string userId, string name, string type)
        {
            var repository = new Repository
            {
                Name = name,
                IsPublic = (type == "Public") ? true : false,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId
            };
            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {

            var repositories = this.db
                .Repositories
                .Where(x => x.IsPublic == true)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    CreatedOn = x.CreatedOn.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    CommitsCount = x.Commits.Count()
                })
                .ToArray();

            return repositories;
        }

        public string GetNameById(string id)
        {
            var repository = this.db.Repositories.FirstOrDefault(x => x.Id == id);

            return repository.Name;
        }
    }
}
