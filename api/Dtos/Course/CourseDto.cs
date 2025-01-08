using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Dtos.Course
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? TeacherId { get; set; }
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
        public List<api.models.Grade> Grades { get; set; } = new List<api.models.Grade>();
    }
}