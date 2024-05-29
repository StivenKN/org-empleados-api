using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace org_empleados.Domain.DTOs.Employee
{
    public class UpdateEmployeeDTO
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [DefaultValue(2)]
        public int FkIdRole { get; set; } = 2;
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
