using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Dtos.Schedule
{
    public class ScheduleDto
    {

        public int Id { get; set; }
        public string GradeLevel { get; set; } = string.Empty;
        public int TimeSlot { get; set; }
        public string Room { get; set; } = string.Empty;
        public int? SectionId { get; set; }
        public List<CourseSchedule> CourseSchedules { get; set; } = new List<CourseSchedule>();
    }
}