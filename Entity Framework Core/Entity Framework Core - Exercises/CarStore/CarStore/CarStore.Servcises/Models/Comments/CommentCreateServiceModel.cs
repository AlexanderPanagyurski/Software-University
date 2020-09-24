using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Services.Models.Comments
{
    public class CommentCreateServiceModel
    {
        public string UserId { get; set; }

        public string Text { get; set; }

        public DateTime WrittenOn { get; set; }

        public string CarId { get; set; }
    }
}
