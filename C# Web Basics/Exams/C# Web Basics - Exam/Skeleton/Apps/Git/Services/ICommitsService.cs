using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(string repositoryId, string userId, string description);

        void Delete(string id);

        IEnumerable<CommitViewModel> GetAll(string repositoryId);

        IEnumerable<UsersCommitsViewModel> GetAllUsersCommits(string userId);
    }
}
