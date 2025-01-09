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
    public class TeacherSectionRepository : ITeacherSectionRepository
    {
        private readonly ApplicationDBContext _context;
        public TeacherSectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TeacherSection?> CreateAsync(TeacherSection teacherSection)
        {
            await _context.TeacherSections.AddAsync(teacherSection);
            await _context.SaveChangesAsync();

            return teacherSection;
        }

        public async Task<List<Section>> GetTeacherSections(Teacher teacher)
        {
            return await _context.TeacherSections.Where(t => t.TeacherId == teacher.Id)
                .Select(section => new Section
                {
                    Id = section.SectionId,
                    GradeLevel = section.Section.GradeLevel,
                }).ToListAsync();
        }
    }
}