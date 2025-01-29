using System.ComponentModel.DataAnnotations;

namespace Evcomp.API.Models
{
    public class OrderEntity
    {
        [Required]
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int ComputerId { get; set; }
        public ComputerEntity Computer { get; set; }
    }
}
