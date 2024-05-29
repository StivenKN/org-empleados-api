using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using org_empleados.Application.Interfaces;
using org_empleados.Domain.DTOs.Users;
using org_empleados.Domain.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace org_empleados.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _userService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<StatusCodeResult>> Post([FromBody] CreateUserDTO userDTO)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            await _userService.CreateUser(userDTO);
            return StatusCode(201);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Ok>> Patch(int id, [FromBody] UpdateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _userService.UpdateUser(id, userDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ok>> Delete(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}
