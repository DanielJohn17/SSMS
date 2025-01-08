using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Grade
{
    public class GradeDto
    {
        public int Id { get; set; }
        public double TotalMarks { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string? TeacherId { get; set; }
        public string? StudentId { get; set; }
        public int? CourseId { get; set; }
    }
}