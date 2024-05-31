using org_empleados.Application.Interfaces;
using org_empleados.Domain.DTOs.Employee;
using org_empleados.Domain.Mappers;
using org_empleados.Domain.Models;

namespace org_empleados.Application.Services
{
    public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = repository;

        public async Task<bool> CreateEmployee(CreateEmployeeDTO employeeDTO)
        {
            Employee employee = employeeDTO.ToModelFromCreateDTO();
            await _employeeRepository.Create(employee);
            return true;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            Employee? employee = await _employeeRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(employee);
            return await _employeeRepository.Delete(employee);
        }

        public async Task<List<Employee>> GetAll(bool activeEmployees)
        {
            if (!activeEmployees)
            {
                return await _employeeRepository.ListAllUnactive();
            }
            return await _employeeRepository.ListAll();
        }

        public async Task<Employee> GetById(int id)
        {
            Employee? employee = await _employeeRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(employee);
            return employee;
        }

        public async Task<Employee> UpdateEmployee(int id, UpdateEmployeeDTO employeeDTO)
        {
            Employee employee = employeeDTO.ToModelFromUpdateDTO();
            Employee? actualEmployee = await _employeeRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(actualEmployee);
            return await _employeeRepository.Update(actualEmployee, employee);
        }
    }
}
