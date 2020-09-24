using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Services.Models.User
{
    public class UserServiceModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public DateTime RegisteredOn { get; set; }

        public bool IsBanned { get; set; }

        public DateTime? BannedOn { get; set; }
    }
}
