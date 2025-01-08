using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
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

        public Task<bool> SectionExists(int id)
        {
            return _context.Sections.AnyAsync(x => x.Id == id);
        }
    }
}