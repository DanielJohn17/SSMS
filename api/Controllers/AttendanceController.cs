using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Attendance;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly ITeacherRepository _teacherRepo;
        public AttendanceController(
            IAttendanceRepository attendanceRepo,
            ICourseRepository courseRepo,
            IStudentRepository studentRepo,
            ITeacherRepository teacherRepo)
        {
            _attendanceRepo = attendanceRepo;
            _courseRepo = courseRepo;
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attendances = await _attendanceRepo.GetAllAsync();
            return Ok(attendances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var attendance = await _attendanceRepo.GetByIdAsync(id);
            if (attendance == null)
                return NotFound();

            return Ok(attendance.ToAttendanceDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromQuery] AttendanceQueryObject queryObject,
            [FromBody] CreateAttendanceDto createAttendanceDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _courseRepo.CourseExistsAsync(queryObject.CourseId))
                return NotFound("Course not found");

            if(!await _studentRepo.StudentExistsAsync(queryObject.StudentId))
                return NotFound("Student not found");

            if(!await _teacherRepo.TeacherExistsAsync(queryObject.TeacherId))
                return NotFound("Teacher not found");

            var attendanceModel = createAttendanceDto.ToAttendance(queryObject);

            await _attendanceRepo.CreateAsync(attendanceModel);

            return CreatedAtAction(nameof(GetById), new { id = attendanceModel.Id }, attendanceModel.ToAttendanceDto());
        }

        // Update will be implemented later

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var attendance = await _attendanceRepo.DeleteAsync(id);
            if (attendance == null)
                return NotFound();

            return NoContent();
        }
    }
}