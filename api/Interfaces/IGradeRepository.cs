using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interfaces
{
    public interface IGradeRepository
    {
        Task<Grade?> GetByIdAsync(int id);
        Task<Grade?> GetByGradeLevelAsync(string gradeLevel);
        Task<Grade?> CreateAsync(Grade gradeModel);
        Task<Grade?> UpdateAsync(int id, Grade gradeModel);
        Task<Grade?> DeleteAsync(int id);
    }
}