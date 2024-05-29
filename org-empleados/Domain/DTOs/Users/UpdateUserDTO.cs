using System.ComponentModel.DataAnnotations;

namespace org_empleados.Domain.DTOs.Users
{
    public class UpdateUserDTO
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public int IdRole { get; set; } = 2;
    }
}
