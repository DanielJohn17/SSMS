using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.models
{
    [Table("Courses")]
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public List<CourseSchedule> CourseSchedules { get; set; } = new List<CourseSchedule>();
        public List<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
    }
}