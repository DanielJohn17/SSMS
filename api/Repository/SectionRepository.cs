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
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationDBContext _context;
        public SectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Section?> CreateAsync(Section sectionModel)
        {
            await _context.Sections.AddAsync(sectionModel);
            await _context.SaveChangesAsync();

            return sectionModel;
        }

        public async Task<Section?> DeleteAsync(int id)
        {
            var sectionModel = await _context.Sections.FindAsync(id);

            if (sectionModel == null)
            {
                return null;
            }

            _context.Remove(sectionModel);
            await _context.SaveChangesAsync();

            return sectionModel;
        }

        public Task<List<Section>> GetAllAsync()
        {
            return _context.Sections.ToListAsync();
        }

        public async Task<Section?> GetByIdAsync(int id)
        {
            return await _context.Sections.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SectionExists(int id)
        {
            return await _context.Sections.AnyAsync(x => x.Id == id);
        }

        public async Task<Section?> UpdateAsync(Section sectionModel)
        {
            var existingSection = await _context.Sections.FindAsync(sectionModel.Id);

            if (existingSection == null)
            {
                return null;
            }

            existingSection.GradeLevel = sectionModel.GradeLevel;

            await _context.SaveChangesAsync();

            return existingSection;
        }
    }
}