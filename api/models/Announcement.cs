using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.models
{
    [Table("Announcements")]
    public class Announcement
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime DateOfMeeting { get; set; } = DateTime.Now;
        public string? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public List<ParentAnnouncement> ParentAnnouncements { get; set; } = new List<ParentAnnouncement>();
    }
}