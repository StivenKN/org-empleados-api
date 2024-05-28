using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace org_empleados.Models
{
    [Table("Employees")]
    public class Employee
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int FkIdRole { get; set; }
        public required Role Role { get; set; }
    }
}
