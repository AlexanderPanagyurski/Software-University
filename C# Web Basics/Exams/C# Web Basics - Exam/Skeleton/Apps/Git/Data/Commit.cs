using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Git.Data
{
    public class Commit
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string CreatorId { get; set; }
        public virtual User Creator { get; set; }

        [ForeignKey(nameof(Repository))]
        public string RepositoryId { get; set; }
        public virtual Repository Repository { get; set; }
    }
}
