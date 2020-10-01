using PetStore.Common;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Services.Products.InputModels
{
    public class AddProductInputServiceModel
    {
        [Required]
        [MinLength(AttributesConstraints.ProductNameMinValue), MaxLength(AttributesConstraints.ProdudctNameMaxValue)]
        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        [Range(typeof(decimal), AttributesConstraints.PriceMinValue, AttributesConstraints.PriceMaxValue)]
        public decimal Price { get; set; }
    }
}
