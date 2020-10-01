using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PetStore.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required,MaxLength(AttributesConstraints.OrderTownNameMaxLength)]
        public string Town { get; set; }

        [Required,MaxLength(AttributesConstraints.OrderAddressNameMaxLength)]
        public string Address { get; set; }

        [MaxLength(AttributesConstraints.OrderNotesMaxValue)]
        public string Notes { get; set; }   

        public decimal TotalPrice { get => this.ClientProducts.Sum(cp => cp.Product.Price * cp.Quantity); }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; } = new HashSet<ClientProduct>();

    }
}
