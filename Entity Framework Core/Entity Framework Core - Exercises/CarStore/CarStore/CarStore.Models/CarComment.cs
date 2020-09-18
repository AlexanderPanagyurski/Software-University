using CarStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarStore.Models
{
    public class CarComment
    {
        public CarComment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(AttributesConstraints.UserFullNameMaxLength)]
        public string UserFullName { get; set; }

        [MaxLength(AttributesConstraints.PhoneMaxLength)]
        public string PhoneNumber { get; set; }

        [MaxLength(AttributesConstraints.EmailMaxLength)]
        public string Email { get; set; }

        [MaxLength(AttributesConstraints.ContentMaxLength)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        //TODO: Users Model

        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
