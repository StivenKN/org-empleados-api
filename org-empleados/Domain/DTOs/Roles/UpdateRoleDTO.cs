using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace org_empleados.Domain.DTOs.Roles
{
    public class UpdateRoleDTO
    {
        [Required]
        public required string Name { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
