using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.models
{
    [Table("Attendances")]
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime DateTaken { get; set; } = DateTime.Now;
        public bool WasPresent { get; set; }


        public int? CourseId { get; set; }
        public string? StudentId { get; set; }
        public string? TeacherId { get; set; }
        public Course? Course { get; set; }
        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
    }
}