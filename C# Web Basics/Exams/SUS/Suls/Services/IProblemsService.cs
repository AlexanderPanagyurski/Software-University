using Suls.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface IProblemsService
    {
        public void Create(string name, int points);

        IEnumerable<IndexLoggedInViewModel> GetAll();

        string GetNameById(string id);

        public ProblemViewModel GetById(string id);
    }
}
