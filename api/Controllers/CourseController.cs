using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Course;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly ITeacherRepository _teacherRepo;
        public CourseController(ICourseRepository courseRepo, ITeacherRepository teacherRepo)
        {
            _courseRepo = courseRepo;
            _teacherRepo = teacherRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepo.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = await _courseRepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost("{teacherId:string}")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto courseDto, string teacherId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _teacherRepo.TeacherExistsAsync(teacherId))
                return NotFound("Teacher does not exist!");

            var courseModel = courseDto.ToCourseFromCreateCourseDto(teacherId);
            await _courseRepo.CreateAsync(courseModel);

            return CreatedAtAction(nameof(GetCourseById), new { id = courseModel.Id }, courseModel);
        }

        // Update will be implemented later

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseModel = await _courseRepo.DeleteAsync(id);

            if (courseModel == null)
                return NotFound();

            return NoContent();
        }

    }
}