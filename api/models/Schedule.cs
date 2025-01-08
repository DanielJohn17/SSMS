using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    [Table("Schedules")]
    public class Schedule
    {
        public int Id { get; set; }
        public string GradeLevel { get; set; } = string.Empty;
        public int TimeSlot { get; set; }
        public string Room { get; set; } = string.Empty;
        public int? SectionId { get; set; }
        public Section? Section { get; set; }
        public List<CourseSchedule> CourseSchedules { get; set; } = new List<CourseSchedule>();
    }
}