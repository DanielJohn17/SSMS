using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Dtos.Section
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string GradeLevel { get; set; } = string.Empty;
        public List<Student> Students { get; set; } = new List<Student>();
    }
}