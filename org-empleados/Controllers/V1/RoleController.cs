using Microsoft.AspNetCore.Mvc;
using org_empleados.Application.Interfaces;
using org_empleados.Domain.DTOs.Roles;
using org_empleados.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace org_empleados.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoleController(IRoleService service) : ControllerBase
    {
        private readonly IRoleService _roleService = service;
        [HttpGet]
        public async Task<ActionResult<List<Role>>> Get()
        {
            return await _roleService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            return await _roleService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CreateRoleDTO roleDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _roleService.CreateRole(roleDTO);
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Role>> Put(int id, [FromBody] UpdateRoleDTO roleDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            Role role = await _roleService.UpdateRole(id, roleDTO);
            return role;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> Delete(int id)
        {
            return await _roleService.DeleteRole(id);
        }
    }
}
