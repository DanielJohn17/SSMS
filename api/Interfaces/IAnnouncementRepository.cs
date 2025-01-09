using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<List<Announcement>> GetAllAsync();
        Task<Announcement?> GetByIdAsync(int id);
        Task<Announcement?> CreateAsync(Announcement announcementModel);
        Task<Announcement?> UpdateAsync(Announcement announcementModel);
        Task<Announcement?> DeleteAsync(int id);
    }
}