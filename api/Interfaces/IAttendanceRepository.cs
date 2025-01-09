using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.models;

namespace api.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(int id);
        Task<Attendance?> CreateAsync(Attendance attendanceModel);
        Task<Attendance?> UpdateAsync(Attendance attendanceModel);
        Task<Attendance?> DeleteAsync(int id);
    }
}