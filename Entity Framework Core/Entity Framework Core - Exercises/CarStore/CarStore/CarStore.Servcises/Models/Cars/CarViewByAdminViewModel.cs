using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Services.Models.Cars
{
    public class CarViewByAdminViewModel
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Views { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsArchived { get; set; }

        public DateTime ArchivedOn { get; set; }

        public bool IsBanned { get; set; }

        public DateTime BannedOn { get; set; }

        public bool IsPromoted { get; set; }

        public DateTime PromotedUntil { get; set; }

    }
}
