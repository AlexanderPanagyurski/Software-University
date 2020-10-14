using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        void ChangePassword(string username, string newPassword);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
