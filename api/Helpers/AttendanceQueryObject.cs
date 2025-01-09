using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class AttendanceQueryObject
    {
        public int CourseId { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string TeacherId { get; set; } = string.Empty;
    }
}