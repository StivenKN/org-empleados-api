using System.ComponentModel.DataAnnotations;

namespace org_empleados.Domain.DTOs.Users
{
    public class CreateUserDTO
    {
        [Required]
        public required string UserName { get; set; }
        [Required, MinLength(8)]
        public required string Password { get; set; }
        public int IdRole { get; set; } = 2;
    }
}
