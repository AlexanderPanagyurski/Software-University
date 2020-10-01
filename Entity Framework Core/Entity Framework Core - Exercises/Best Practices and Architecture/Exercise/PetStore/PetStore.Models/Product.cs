using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required,MaxLength(AttributesConstraints.ProdudctNameMaxValue)]
        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        [Range(typeof(decimal),AttributesConstraints.PriceMinValue,AttributesConstraints.PriceMaxValue)]
        public decimal Price { get; set; }


        public virtual ICollection<ClientProduct> ClientProducts { get; set; } = new HashSet<ClientProduct>();
    }
}
