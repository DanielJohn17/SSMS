using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Section
{
    public class CreateSectionDto
    {
        [Required]
        [Length(2, 2, ErrorMessage = "Grade Level must be 2 characters")]
        public string GradeLevel { get; set; } = string.Empty;
    }
}