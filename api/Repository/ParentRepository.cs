using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDBContext _context;
        public ParentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> ParentExists(string parentId)
        {
            return await _context.Parents.AnyAsync(x => x.Id == parentId);
        }
    }
}