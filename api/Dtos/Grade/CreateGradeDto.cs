using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Grade
{
    public class CreateGradeDto
    {
        public double TotalMarks { get; set; }
        public string? TeacherId { get; set; }
        public string? StudentId { get; set; }
        public int? CourseId { get; set; }
    }
}