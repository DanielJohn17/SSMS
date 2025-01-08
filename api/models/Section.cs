using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.models
{
    [Table("Sections")]
    public class Section
    {
        public int Id { get; set; }
        public string GradeLevel { get; set; } = string.Empty;
        public Schedule? Schedule { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<TeacherSection> TeacherSections { get; set; } = new List<TeacherSection>();
    }
}