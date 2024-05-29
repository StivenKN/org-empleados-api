using org_empleados.Domain.DTOs.Employee;
using org_empleados.Domain.Models;

namespace org_empleados.Domain.Mappers
{
    public static class EmployeeMappers
    {
        public static Employee CreateEmployeeFromDTO(this CreateEmployeeDTO employeeDTO)
        {
            return new Employee { FirstName = employeeDTO.FirstName, FkIdRole = employeeDTO.FkIdRole, LastName = employeeDTO.LastName };
        }

        public static Employee UpdateEmployeeFromDTO(this UpdateEmployeeDTO employeeDTO)
        {
            return new Employee { FirstName = employeeDTO.FirstName, FkIdRole = employeeDTO.FkIdRole, LastName = employeeDTO.LastName };
        }
    }
}
