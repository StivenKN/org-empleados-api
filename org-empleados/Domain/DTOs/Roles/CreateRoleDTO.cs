using System.ComponentModel.DataAnnotations;

namespace org_empleados.Domain.DTOs.Roles
{
    public class CreateRoleDTO
    {
        [Required]
        public required string Name { get; set; }
    }
}
