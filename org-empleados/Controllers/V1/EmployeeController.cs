using Microsoft.AspNetCore.Mvc;
using org_empleados.Application.Interfaces;
using org_empleados.Domain.DTOs.Employee;
using org_empleados.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace org_empleados.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService service) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = service;

        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await _employeeService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _employeeService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeDTO employeeDTO)
        {
            await _employeeService.CreateEmployee(employeeDTO);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] UpdateEmployeeDTO employeeDTO)
        {
            await _employeeService.UpdateEmployee(id, employeeDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
