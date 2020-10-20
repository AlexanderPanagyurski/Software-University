using Suls.Data;
using System;
using System.Collections.Generic;
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
    }
}
