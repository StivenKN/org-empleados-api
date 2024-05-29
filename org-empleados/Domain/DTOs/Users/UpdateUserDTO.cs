using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace org_empleados.Domain.DTOs.Users
{
    public class UpdateUserDTO
    {
        [AllowNull]
        public string? UserName { get; set; } = null;
        [AllowNull]
        public string? Password { get; set; } = null;
        [DefaultValue(2)]
        public int IdRole { get; set; } = 2;
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
