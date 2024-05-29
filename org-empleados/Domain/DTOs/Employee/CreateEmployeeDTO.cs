using org_empleados.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace org_empleados.Domain.DTOs.Employee
{
    public class CreateEmployeeDTO
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [JsonIgnore]
        public int FkIdRole { get; set; } = 2;
    }
}
