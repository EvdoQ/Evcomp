using System.ComponentModel.DataAnnotations;

namespace Evcomp.API.Models
{
    public class EmployeeEntity
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Contacts { get; set; } = string.Empty;
        public int Experience { get; set; } = 0;
        public ICollection<OrderEntity> Orders { get; set; } = [];
    }
}
