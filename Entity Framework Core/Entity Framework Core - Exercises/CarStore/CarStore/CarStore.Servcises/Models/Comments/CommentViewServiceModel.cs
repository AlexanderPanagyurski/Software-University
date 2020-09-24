using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Services.Models.Comments
{
    public class CommentViewServiceModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string Text { get; set; }

        public string WrittenOn { get; set; }
    }
}
