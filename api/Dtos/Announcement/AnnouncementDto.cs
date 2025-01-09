using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Announcement
{
    public class AnnouncementDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime DateOfMeeting { get; set; }
        public string? TeacherId { get; set; }
    }
}