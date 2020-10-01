using PetStore.Common;
using PetStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetStore.Models
{
    public class Pet
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required,MaxLength(AttributesConstraints.PetNameMaxLength)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(AttributesConstraints.PetAgeMaxValue)]
        public byte Age { get; set; }


        public bool IsSold { get; set; }

        [Range(typeof(decimal),AttributesConstraints.PriceMinValue,AttributesConstraints.PriceMaxValue)]
        public decimal Price { get; set; }


        [Required, ForeignKey(nameof(Breed))]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }


        [Required,ForeignKey(nameof(Client))]
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
