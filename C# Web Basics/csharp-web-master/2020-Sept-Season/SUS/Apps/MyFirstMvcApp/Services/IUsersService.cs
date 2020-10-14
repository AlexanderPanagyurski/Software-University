using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        bool IsUserValid(string username, string password);

        void ChangePassword(string username, string newPassword);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
