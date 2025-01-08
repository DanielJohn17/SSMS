using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.models;

namespace api.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDBContext _context;
        public GradeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Grade?> CreateAsync(Grade gradeModel)
        {
            await _context.Grades.AddAsync(gradeModel);
            await _context.SaveChangesAsync();
            return gradeModel;
        }

        public async Task<Grade?> DeleteAsync(int id)
        {
            var gradeModel = await _context.Grades.FindAsync(id);
            if (gradeModel == null)
                return null;

            _context.Grades.Remove(gradeModel);
            await _context.SaveChangesAsync();

            return gradeModel;
        }

        public Task<Grade?> GetByGradeLevelAsync(string gradeLevel)
        {
            throw new NotImplementedException();
        }

        public async Task<Grade?> GetByIdAsync(int id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public Task<Grade?> UpdateAsync(int id, Grade gradeModel)
        {
            throw new NotImplementedException();
        }
    }
}