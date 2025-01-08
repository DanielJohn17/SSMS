using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using Microsoft.AspNetCore.Identity;

namespace api.models
{
    public class Student : AppUser
    {
        public int? SectionId { get; set; }
        public string? ParentId { get; set; }
        public Section? Section { get; set; }
        public Parent? Parent { get; set; }
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public List<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
    }
}