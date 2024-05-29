using org_empleados.Domain.DTOs.Roles;
using org_empleados.Domain.Models;

namespace org_empleados.Mappers
{
    public static class RoleMappers
    {
        public static Role ToModelFromCreateDTO(this CreateRoleDTO roleDTO)
        {
            return new Role { Name = roleDTO.Name }; 
        }

        public static Role ToModelFromUpdateDTO(this UpdateRoleDTO roleDTO)
        {
            return new Role { Name = roleDTO.Name, UpdatedAt = roleDTO.UpdatedAt };
        }
    }
}
