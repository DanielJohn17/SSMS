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
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDBContext _context;
        public CourseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CourseExistsAsync(int id)
        {
            return await _context.Courses.AnyAsync(x => x.Id == id);
        }

        public async Task<Course?> CreateAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course?> DeleteAsync(int id)
        {
            var courseModel = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (courseModel == null)
            {
                return null;
            }

            _context.Courses.Remove(courseModel);
            await _context.SaveChangesAsync();

            return courseModel;
        }

        public Task<List<Course>> GetAllAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Course?> UpdateAsync(Course course)
        {
            throw new NotImplementedException();
        }
    }
}