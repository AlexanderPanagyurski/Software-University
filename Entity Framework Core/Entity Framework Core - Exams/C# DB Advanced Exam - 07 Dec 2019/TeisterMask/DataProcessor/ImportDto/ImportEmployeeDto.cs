using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Datasets;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        [RegularExpression(@"(^[A-Z]+$)|(^[a-z]+$)|(^[A-Z0-9]+$)|(^[a-z0-9]+$)")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public ImportTaskIdDto[] Tasks { get; set; }
    }
}
