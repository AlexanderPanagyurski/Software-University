using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PetStore.Common;
using System.Text;

namespace PetStore.Models
{
    public class Breed
    {
        public int Id { get; set; }

        [Required,MaxLength(AttributesConstraints.BreedNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
    }
}
