using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDBContext _context;
        public TeacherRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> TeacherExistsAsync(string id)
        {
            return await _context.Teachers.AnyAsync(x => x.Id == id);
        }
    }
}