using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace api.models
{
    [Table("CourseStudents")]
    public class CourseStudent
    {
        public int? CourseId { get; set; }
        public string? StudentId { get; set; }
        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}
