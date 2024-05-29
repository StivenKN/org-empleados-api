using org_empleados.Application.Interfaces;
using org_empleados.Application.Lib;
using org_empleados.Domain.Models;

namespace org_empleados.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<string> Create()
        {
            throw new NotImplementedException();
        }

        public Task<string> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ListOne()
        {
            throw new NotImplementedException();
        }
    }
}
