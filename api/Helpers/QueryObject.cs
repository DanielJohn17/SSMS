using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        public string TeacherId { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public int CourseId { get; set; }
    }
}