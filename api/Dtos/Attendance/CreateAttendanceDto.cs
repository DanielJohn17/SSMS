using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Attendance
{
    public class CreateAttendanceDto
    {
        public bool WasPresent { get; set; }
        public int? CourseId { get; set; }
        public string? StudentId { get; set; }
        public string? TeacherId { get; set; }
    }
}