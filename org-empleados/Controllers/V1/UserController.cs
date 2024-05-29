﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using org_empleados.Application.Interfaces;
using org_empleados.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace org_empleados.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _userService.GetAll();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<User>> Get(string username)
        {
            return await _userService.GetByUsername(username);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            await _userService.DeleteUser(username);
            return Ok();
        }
    }
}
