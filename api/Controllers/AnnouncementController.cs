using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Announcement;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/announcement")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementRepository _announcementRepo;
        private readonly ITeacherRepository _teacherRepo;
        public AnnouncementController(IAnnouncementRepository announcementRepo, ITeacherRepository teacherRepo)
        {
            _announcementRepo = announcementRepo;
            _teacherRepo = teacherRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var announcements = await _announcementRepo.GetAllAsync();

            return Ok(announcements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var announcement = await _announcementRepo.GetByIdAsync(id);

            if (announcement == null)
                return NotFound();

            return Ok(announcement.ToAnnouncementDto());
        }

        [HttpPost("{teacherId:guid}")]
        public async Task<IActionResult> Create([FromBody] CreateAnnouncementDto announcementDto, Guid teacherId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var teacherIdString = teacherId.ToString();

            if (!await _teacherRepo.TeacherExistsAsync(teacherIdString))
                return NotFound("Teacher does not exist!");

            var announcementModel = announcementDto.ToAnnouncement(teacherIdString);
            await _announcementRepo.CreateAsync(announcementModel);

            return CreatedAtAction(nameof(GetById), new { id = announcementModel.Id }, announcementModel.ToAnnouncementDto());
        }

        // Update will be implemented later

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var announcement = await _announcementRepo.DeleteAsync(id);

            if (announcement == null)
                return NotFound();

            return NoContent();
        }
    }
}