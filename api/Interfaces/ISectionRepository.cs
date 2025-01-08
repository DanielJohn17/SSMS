using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interfaces
{
    public interface ISectionRepository
    {
        Task<List<Section>> GetAllAsync();
        Task<Section?> GetByIdAsync(int id);
        Task<Section?> CreateAsync(Section sectionModel);
        Task<Section?> UpdateAsync(Section sectionModel);
        Task<Section?> DeleteAsync(int id);
        Task<bool> SectionExists(int id);
    }
}