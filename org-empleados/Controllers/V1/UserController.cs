using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using org_empleados.Application.Interfaces;
using org_empleados.Domain.DTOs.Users;
using org_empleados.Domain.Models;

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
        public async Task<ActionResult<User>> Get(string id)
        {
            return await _userService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDTO userDTO)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            await _userService.CreateUser(userDTO);
            return StatusCode(201);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] UpdateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _userService.UpdateUser(id, userDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}
