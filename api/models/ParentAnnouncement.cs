using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.models;




namespace api.models
{
    [Table("ParentAnnouncements")]
    public class ParentAnnouncement
    {
        public string? ParentId { get; set; }
        public int? AnnouncementId { get; set; }
        public Parent? Parent { get; set; }
        public Announcement? Announcement { get; set; }
    }
}
