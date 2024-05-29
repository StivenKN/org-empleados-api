using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace org_empleados.Domain.DTOs.Users
{
    public class UpdateUserDTO
    {
        [AllowNull]
        public string? UserName { get; set; } = null;
        [AllowNull]
        public string? Password { get; set; } = null;
        public int IdRole { get; set; } = 2;
    }
}
