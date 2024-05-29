using org_empleados.Domain.DTOs.Employee;
using org_empleados.Domain.Models;

namespace org_empleados.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<bool> CreateEmployee(CreateEmployeeDTO employeeDTO);
        Task<Employee> UpdateEmployee(int id, UpdateEmployeeDTO employeeDTO);
        Task<Employee> DeleteEmployee(int id);
    }
}
