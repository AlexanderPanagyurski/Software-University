using System;
using System.Collections.Generic;

namespace Exam28June2020.Models
{
    public partial class Spaceship
    {
        public Spaceship()
        {
            Journeys = new HashSet<Journey>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int? LightSpeedRate { get; set; }

        public virtual ICollection<Journey> Journeys { get; set; }
    }
}
