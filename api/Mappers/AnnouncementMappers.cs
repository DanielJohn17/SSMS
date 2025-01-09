using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Announcement;
using api.models;

namespace api.Mappers
{
    public static class AnnouncementMappers
    {
        public static AnnouncementDto ToAnnouncementDto(this Announcement announcement)
        {
            return new AnnouncementDto
            {
                Id = announcement.Id,
                Message = announcement.Message,
                DateOfMeeting = announcement.DateOfMeeting,
                TeacherId = announcement.TeacherId
            };
        }

        public static Announcement ToAnnouncement(this CreateAnnouncementDto createAnnouncementDto, string teacherId)
        {
            return new Announcement
            {
                Message = createAnnouncementDto.Message,
                TeacherId = teacherId
            };
        }
    }
}