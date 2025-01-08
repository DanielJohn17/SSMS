using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace api.models
{
    [Table("TeacherSections")]
    public class TeacherSection
    {
        public string? TeacherId { get; set; }
        public int? SectionId { get; set; }
        public Teacher? Teacher { get; set; }
        public Section? Section { get; set; }
    }
}
