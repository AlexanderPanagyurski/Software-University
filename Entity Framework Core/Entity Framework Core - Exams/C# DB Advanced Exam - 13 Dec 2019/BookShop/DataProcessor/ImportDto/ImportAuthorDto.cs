using BookShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorDto
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        //[RegularExpression("^[A-z]+@[A-z.]+\.[A-z]+$")]
        public string Email { get; set; }

        [Required]
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public virtual ImportAuthorBookDto[] Books { get; set; }
    }
}
