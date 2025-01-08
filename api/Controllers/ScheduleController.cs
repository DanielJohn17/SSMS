using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Schedule;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepo;
        private readonly ISectionRepository _sectionRepo;
        public ScheduleController(IScheduleRepository scheduleRepo, ISectionRepository sectionRepo)
        {
            _scheduleRepo = scheduleRepo;
            _sectionRepo = sectionRepo;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var schedule = await _scheduleRepo.GetByIdAsync(id);

            if (schedule == null)
                return NotFound();

            return Ok(schedule.ToScheduleDto());
        }

        [HttpGet("section/{sectionId:int}")]
        public async Task<IActionResult> GetBySectionId([FromRoute] int sectionId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var schedule = await _scheduleRepo.GetBySectionIdAsync(sectionId);

            if (schedule == null)
                return NotFound();

            return Ok(schedule.ToScheduleDto());
        }

        [HttpPost("{sectionId:int}")]
        public async Task<IActionResult> Create([FromRoute] int sectionId, [FromBody] CreateScheduleDto scheduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _sectionRepo.SectionExists(sectionId))
            {
                return BadRequest("Section does not exist!");
            }

            var scheduleModel = scheduleDto.ToScheduleFromCreateScheduleDto(sectionId);
            await _scheduleRepo.CreateAsync(scheduleModel);
            return CreatedAtAction(nameof(GetBySectionId), new { id = scheduleModel.Id }, scheduleModel.ToScheduleDto());
        }
    }
}