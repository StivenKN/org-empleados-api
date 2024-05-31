using org_empleados.Domain.Models;

namespace org_empleados.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> ListAll();
        Task<List<Employee>> ListAllUnactive();
        Task<Employee?> ListOne(int id);
        Task<bool> Create(Employee employee);
        Task<Employee> Update(Employee actualEmployee, Employee newEmployee);
        Task<Employee> Delete(Employee employee);
    }
}
