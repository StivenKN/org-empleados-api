using System.ComponentModel.DataAnnotations;

namespace org_empleados.Domain.DTOs.Users
{
    public class LoginUserDTO
    {
        [Required]
        public required string UserName { get; set; }
        [Required, MinLength(8)]
        public required string Password { get; set; }
    }
}
