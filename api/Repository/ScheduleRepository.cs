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
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDBContext _context;
        public ScheduleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Schedule?> CreateAsync(Schedule scheduleModel)
        {
            await _context.Schedules.AddAsync(scheduleModel);
            await _context.SaveChangesAsync();
            return scheduleModel;
        }

        public async Task<Schedule?> DeleteAsync(int id)
        {
            var scheduleModel = await _context.Schedules.FindAsync(id);

            if (scheduleModel == null)
            {
                return null;
            }

            _context.Schedules.Remove(scheduleModel);
            await _context.SaveChangesAsync();

            return scheduleModel;
        }

        public async Task<Schedule?> GetByIdAsync(int id)
        {
            return await _context.Schedules.FindAsync(id);
        }

        public async Task<Schedule?> GetBySectionIdAsync(int sectionId)
        {
            return await _context.Schedules.FirstOrDefaultAsync(x => x.SectionId == sectionId);
        }

        public async Task<Schedule?> UpdateAsync(int id, Schedule scheduleModel)
        {
            var existingSchedule = await _context.Schedules.FindAsync(id);

            if (existingSchedule == null)
            {
                return null;
            }

            existingSchedule.GradeLevel = scheduleModel.GradeLevel;
            existingSchedule.TimeSlot = scheduleModel.TimeSlot;
            existingSchedule.Room = scheduleModel.Room;

            await _context.SaveChangesAsync();

            return existingSchedule;
        }
    }
}