using PetStore.Common;
using PetStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class Client
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required,MaxLength(AttributesConstraints.UsernameameMaxLength)]
        public string Username { get; set; }

        [Required,MaxLength(AttributesConstraints.PasswordMaxLength)]
        public string Password { get; set; }

        [Required,MaxLength(AttributesConstraints.EmailMaxLength)]
        public string Email { get; set; }
        
        [Required,MaxLength(AttributesConstraints.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required,MaxLength(AttributesConstraints.LastNameMaxLength)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        public virtual ICollection<ClientProduct> ClientProducts { get; set; } = new HashSet<ClientProduct>();
    }
}
