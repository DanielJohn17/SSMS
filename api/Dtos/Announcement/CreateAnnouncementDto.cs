using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Announcement
{
    public class CreateAnnouncementDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Message must be at least 5 characters long")]
        [MaxLength(500, ErrorMessage = "Message cannot be longer than 500 characters")]
        public string Message { get; set; } = string.Empty;
        [Required]
        public string TeacherId { get; set; } = string.Empty;
    }
}