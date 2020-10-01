using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public enum ProductType
    {
        Unknown = 0,
        Food = 1,
        Toy = 2,
        Decoration = 3,
        Water = 4
    }
}
