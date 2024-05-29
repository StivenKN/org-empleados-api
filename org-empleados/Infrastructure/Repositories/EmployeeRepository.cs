using Microsoft.EntityFrameworkCore;
using org_empleados.Application.Interfaces;
using org_empleados.Application.Lib;
using org_empleados.Domain.Data;
using org_empleados.Domain.Models;

namespace org_empleados.Infrastructure.Repositories
{
    public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> Create(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> Delete(Employee employee)
        {
            employee.DeletedAt = DateTime.Now;
            employee.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> ListAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> ListOne(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Employee> Update(Employee actualEmployee, Employee newEmployee)
        {
            actualEmployee.FirstName = newEmployee.FirstName;
            actualEmployee.LastName = newEmployee.LastName;
            actualEmployee.FkIdRole = newEmployee.FkIdRole;
            actualEmployee.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return actualEmployee;
        }
    }
}
