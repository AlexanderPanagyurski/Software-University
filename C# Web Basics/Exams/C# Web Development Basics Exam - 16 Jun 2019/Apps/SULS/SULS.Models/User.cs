using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = new Guid().ToString();

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();

    }
}