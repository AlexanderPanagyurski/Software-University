using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Git.Data
{
    public class Repository
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(10)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
