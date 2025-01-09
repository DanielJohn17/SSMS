using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interfaces
{
    public interface ITeacherSectionRepository
    {
        Task<List<Section>> GetTeacherSections(Teacher teacher);
        Task<TeacherSection?> CreateAsync(TeacherSection teacherSection);
    }
}