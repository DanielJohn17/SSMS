using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/teacher-section")]
    [ApiController]
    public class TeacherSectionController : ControllerBase
    {
        private readonly ITeacherSectionRepository _teacherSectionRepo;
        private readonly UserManager<Teacher> _userManager;
        private readonly ISectionRepository _sectionRepo;
        public TeacherSectionController(
            ITeacherSectionRepository teacherSectionRepo,
            UserManager<Teacher> userManager,
            ISectionRepository sectionRepo)
        {
            _teacherSectionRepo = teacherSectionRepo;
            _userManager = userManager;
            _sectionRepo = sectionRepo;
        }

        [HttpGet("{teacherId:guid}")]
        public async Task<IActionResult> GetTeacherSections([FromRoute] Guid teacherId)
        {
            var teacher = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(teacher);
            var teacherSections = await _teacherSectionRepo.GetTeacherSections(appUser);

            return Ok(teacherSections);
        }

        [HttpPost("{SectionId:int}")]
        public async Task<IActionResult> AddTeacherSection(int SectionId)
        {
            var teacher = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(teacher);
            var section = await _sectionRepo.GetByIdAsync(SectionId);

            if (section == null)
                return BadRequest("Section does not exist");

            var teacherSection = await _teacherSectionRepo.GetTeacherSections(appUser);

            if(teacherSection.Any(s => s.Id == SectionId))
                return BadRequest("Teacher already assigned to this section");

            var newTeacherSection = new TeacherSection
            {
                TeacherId = appUser.Id,
                SectionId = SectionId
            };

            await _teacherSectionRepo.CreateAsync(newTeacherSection);

            if(teacherSection == null)
                return StatusCode(500, "Failed to add stock to portfolio");
            else
                return Created();
        }
    }
}