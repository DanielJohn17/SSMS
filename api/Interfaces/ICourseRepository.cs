using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course?> CreateAsync(Course course);
        Task<Course?> UpdateAsync(Course course);
        Task<Course?> DeleteAsync(int id);
        Task<bool> CourseExistsAsync(int id);
    }
}