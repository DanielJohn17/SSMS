using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly ApplicationDBContext _context;
        public AnnouncementRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Announcement?> CreateAsync(Announcement announcementModel)
        {
            await _context.Announcements.AddAsync(announcementModel);
            await _context.SaveChangesAsync();

            return announcementModel;
        }

        public async Task<Announcement?> DeleteAsync(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);

            if (announcement == null)
                return null;

            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();

            return announcement;
        }

        public async Task<List<Announcement>> GetAllAsync()
        {
            return await _context.Announcements.ToListAsync();
        }

        public async Task<Announcement?> GetByIdAsync(int id)
        {
            return await _context.Announcements.FindAsync(id);
        }

        public Task<Announcement?> UpdateAsync(Announcement announcementMdoel)
        {
            throw new NotImplementedException();
        }
    }
}