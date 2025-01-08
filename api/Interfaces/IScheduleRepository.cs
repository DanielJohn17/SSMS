using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interfaces
{
    public interface IScheduleRepository
    {
        Task<Schedule?> GetByIdAsync(int id);
        Task<Schedule?> GetBySectionIdAsync(int sectionId);
        Task<Schedule?> CreateAsync(Schedule scheduleModel);
        Task<Schedule?> UpdateAsync(int id, Schedule scheduleModel);
        Task<Schedule?> DeleteAsync(int id);
    }
}