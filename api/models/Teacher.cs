using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using Microsoft.AspNetCore.Identity;

namespace api.models
{
    public class Teacher : IdentityUser
    {
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Announcement> Announcements { get; set; } = new List<Announcement>();
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public List<TeacherSection> TeacherSections { get; set; } = new List<TeacherSection>();
    }
}