using Suls.Data;
using Suls.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suls.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };
            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<IndexLoggedInViewModel> GetAll()
        {
            var problems = this.db.Problems.Select(x => new IndexLoggedInViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count()
            })
            .ToList();
            return problems;
        }

        public string GetNameById(string id)
        {
            var problem = this.db.Problems.FirstOrDefault(x => x.Id == id);
            return problem?.Name;
        }
    }
}
