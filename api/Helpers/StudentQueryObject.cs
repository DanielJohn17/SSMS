using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class StudentQueryObject
    {
        public int SectionId { get; set; }
        public string ParentId { get; set; } = string.Empty;
    }
}