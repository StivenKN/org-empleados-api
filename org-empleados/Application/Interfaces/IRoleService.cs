using org_empleados.Domain.DTOs.Roles;
using org_empleados.Domain.Models;

namespace org_empleados.Application.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAll();
        Task<Role> GetById(int id);
        Task<bool> CreateRole(CreateRoleDTO role);
        Task<Role> UpdateRole(int id, UpdateRoleDTO role);
        Task<Role> DeleteRole(int id);
    }
}
