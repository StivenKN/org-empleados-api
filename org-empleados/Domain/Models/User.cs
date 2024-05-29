using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace org_empleados.Domain.Models
{
    public class User : IdentityUser
    {
        [Required]
        public int? FkIdRole { get; set; } = 2;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = null;
        [JsonIgnore]
        public Role? Role { get; set; } = null;
    }
}
