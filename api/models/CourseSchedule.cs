using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.models;


namespace api.models
{
    [Table("CourseSchedules")]
    public class CourseSchedule
    {
        public int? CourseId { get; set; }
        public int? ScheduleId { get; set; }
        public Course? Course { get; set; }
        public Schedule? Schedule { get; set; }
    }
}
