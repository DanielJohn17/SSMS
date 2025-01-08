using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Course;
using api.models;

namespace api.Mappers
{
    public static class CourseMappers
    {
        public static CourseDto ToCourseDto(this models.Course course)
        {
            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                TeacherId = course.TeacherId,
                Attendances = course.Attendances,
                Grades = course.Grades
            };
        }

        public static Course ToCourseFromCreateCourseDto(this CreateCourseDto createCourseDto, string teacherId)
        {
            return new Course
            {
                Name = createCourseDto.Name,
                TeacherId = teacherId
            };
        }
    }
}