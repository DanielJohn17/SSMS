using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Section;
using api.Interfaces;
using api.Mappers;
using api.models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/section")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository _sectionRepo;
        public SectionController(ISectionRepository sectionRepo)
        {
            _sectionRepo = sectionRepo;            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var sections = await _sectionRepo.GetAllAsync();
            return Ok(sections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var section = await _sectionRepo.GetByIdAsync(id);

            if (section == null)
                return NotFound();

                return Ok(section.ToSectionDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSectionDto sectionDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var sectionModel = sectionDto.ToSectionFromCreateSectionDto();
            await _sectionRepo.CreateAsync(sectionModel);

            return CreatedAtAction(nameof(GetById), new { id = sectionModel.Id }, sectionModel.ToSectionDto());
        }

        // Update Section will be implemented later

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var section = await _sectionRepo.GetByIdAsync(id);

            if (section == null)
                return NotFound();

            await _sectionRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}