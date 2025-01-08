using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Grade;
using api.models;

namespace api.Mappers
{
    public static class GradeMappers
    {
        public static GradeDto ToGradeDto(this Grade gradeModel)
        {
            return new GradeDto
            {
                Id = gradeModel.Id,
                TotalMarks = gradeModel.TotalMarks,
                DateSubmitted = gradeModel.DateSubmitted,
                TeacherId = gradeModel.TeacherId,
                StudentId = gradeModel.StudentId,
                CourseId = gradeModel.CourseId
            };
        }

        public static Grade ToGradeFromCreateGradeDto(this CreateGradeDto createGradeDto)
        {
            return new Grade
            {
                TotalMarks = createGradeDto.TotalMarks,
                TeacherId = createGradeDto.TeacherId,
                StudentId = createGradeDto.StudentId,
                CourseId = createGradeDto.CourseId
            };
        }
    }
}