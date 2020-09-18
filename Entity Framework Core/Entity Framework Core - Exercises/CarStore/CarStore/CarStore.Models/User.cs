using CarStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarStore.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }


        [Required, MaxLength(AttributesConstraints.FirstNameMaxValue)]
        public string FirstName { get; set; }

        [Required, MaxLength(AttributesConstraints.LastNameMaxValue)]
        public string LastName { get; set; }

        [Required, MaxLength(AttributesConstraints.UsernameMaxValue)]
        public string Username { get; set; }

        [Required, MaxLength(AttributesConstraints.EmailMaxLength)]
        public string Email { get; set; }

        [Required, MaxLength(AttributesConstraints.PhoneMaxLength)]
        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegisteredOn { get; set; }

        public string ImageUrl { get; set; }

        public bool IsBlocked { get; set; }

        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
