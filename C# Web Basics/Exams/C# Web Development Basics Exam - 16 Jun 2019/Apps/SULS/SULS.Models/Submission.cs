using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SULS.Models
{
    public class Submission
    {
        [Key]
        public string Id { get; set; } = new Guid().ToString();

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }


        [Range(0,300)]
        public int AchivedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Problem))]
        public string ProblemId { get; set; }
        public virtual Problem Problem { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
