using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Grade;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _gradeRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly ICourseRepository _courseRepo;
        public GradeController(
            IGradeRepository gradeRepo,
            IStudentRepository studentRepo,
            ITeacherRepository teacherRepo,
            ICourseRepository courseRepo)
        {
            _gradeRepo = gradeRepo;
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
            _courseRepo = courseRepo;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var grade = await _gradeRepo.GetByIdAsync(id);

            if (grade == null)
                return NotFound();

            return Ok(grade.ToGradeDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] QueryObject queryObject, [FromBody] CreateGradeDto gradeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _courseRepo.CourseExistsAsync(queryObject.CourseId))
            {
                return BadRequest("Course does not exist!");
            }

            if(!await _studentRepo.StudentExistsAsync(queryObject.StudentId))
            {
                return BadRequest("Student does not exist!");
            }

            if(!await _teacherRepo.TeacherExistsAsync(queryObject.TeacherId))
            {
                return BadRequest("Teacher does not exist!");
            }

            var gradeModel = gradeDto.ToGradeFromCreateGradeDto();
            await _gradeRepo.CreateAsync(gradeModel);
            return CreatedAtAction(nameof(GetById), new { id = gradeModel.Id }, gradeModel.ToGradeDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var grade = await _gradeRepo.DeleteAsync(id);

            if (grade == null)
                return NotFound();

            return Ok(grade.ToGradeDto());
        }

        // Update method will be implemented later
    }
}