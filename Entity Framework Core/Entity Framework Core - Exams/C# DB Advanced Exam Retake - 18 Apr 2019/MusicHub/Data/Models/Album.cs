using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Producer))]
        public int ProducedId { get; set; }
        public Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
