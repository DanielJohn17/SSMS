using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Course
{
    public class CreateCourseDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string? TeacherId { get; set; }
    }
}