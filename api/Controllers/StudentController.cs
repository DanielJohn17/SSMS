using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Teacher;
using api.Helpers;
using api.Interfaces;
using api.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/studnet")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ISectionRepository _sectionRepo;
        private readonly IParentRepository _parentRepo;

        public StudentController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ISectionRepository sectionRepo,
            IParentRepository parentRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _sectionRepo = sectionRepo;
            _parentRepo = parentRepo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if (user == null)
                return BadRequest("Invalid user!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized("User not found and/or Password incorrect");

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterDto registerDto,
            [FromQuery] StudentQueryObject queryObjct)
        {
            try {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if(!await _sectionRepo.SectionExists(queryObjct.SectionId))
                    return BadRequest("Invalid Section!");

                if(!await _parentRepo.ParentExists(queryObjct.ParentId))
                    return BadRequest("Invalid Parent!");

                var student = new Student
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    SectionId = queryObjct.SectionId,
                    ParentId = queryObjct.ParentId,
                };

                var createdUser = await _userManager.CreateAsync(student, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    return Ok(
                        new NewUserDto
                        {
                            UserName = student.UserName,
                            Email = student.Email,
                        }
                    );
                } else {
                    return StatusCode(500, createdUser.Errors);
                }
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }
}