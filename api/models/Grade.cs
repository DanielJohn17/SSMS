using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    [Table("Grades")]
    public class Grade
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public double TotalMarks { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public string? TeacherId { get; set; }
        public string? StudentId { get; set; }
        public int? CourseId { get; set; }
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}