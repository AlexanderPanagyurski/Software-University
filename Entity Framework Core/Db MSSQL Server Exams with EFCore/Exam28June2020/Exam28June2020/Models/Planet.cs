using System;
using System.Collections.Generic;

namespace Exam28June2020.Models
{
    public partial class Planet
    {
        public Planet()
        {
            Spaceports = new HashSet<Spaceport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Spaceport> Spaceports { get; set; }
    }
}
