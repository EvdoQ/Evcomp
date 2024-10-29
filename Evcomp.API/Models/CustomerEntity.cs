using System.ComponentModel.DataAnnotations;

namespace Evcomp.API.Models
{
    public class CustomerEntity
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Contacts { get; set; } = string.Empty;
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
