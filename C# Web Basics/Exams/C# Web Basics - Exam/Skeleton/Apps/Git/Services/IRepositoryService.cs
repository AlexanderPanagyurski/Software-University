using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoryService
    {
        void Create(string userId, string name, string type);

        string GetNameById(string id);

        IEnumerable<RepositoryViewModel> GetAll();
    }
}
