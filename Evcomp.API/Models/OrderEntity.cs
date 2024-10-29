using System.ComponentModel.DataAnnotations;

namespace Evcomp.API.Models
{
    public class OrderEntity
    {
        [Required]
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }
        public int ComputerId { get; set; }
        public ComputerEntity Computer { get; set; }
    }
}
