using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Section;
using api.models;

namespace api.Mappers
{
    public static class SectionMappers
    {
        public static SectionDto ToSectionDto(this Section section)
        {
            return new SectionDto
            {
                Id = section.Id,
                GradeLevel = section.GradeLevel,
                Students = section.Students
            };
        }

        public static Section ToSectionFromCreateSectionDto(this CreateSectionDto createSectionDto)
        {
            return new Section
            {
                GradeLevel = createSectionDto.GradeLevel
            };
        }
    }
}