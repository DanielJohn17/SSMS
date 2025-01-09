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
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDBContext _context;
        public AttendanceRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Attendance?> CreateAsync(Attendance attendanceModel)
        {
            await _context.Attendances.AddAsync(attendanceModel);
            await _context.SaveChangesAsync();

            return attendanceModel;
        }

        public async Task<Attendance?> DeleteAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
                return null;

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();

            return attendance;
        }

        public async Task<List<Attendance>> GetAllAsync()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public Task<Attendance?> UpdateAsync(Attendance attendanceModel)
        {
            throw new NotImplementedException();
        }
    }
}