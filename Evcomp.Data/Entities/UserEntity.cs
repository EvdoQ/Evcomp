using System.ComponentModel.DataAnnotations;

namespace Evcomp.API.Models
{
    public class UserEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string Contacts { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Customer";

        public ICollection<OrderEntity> Orders { get; set; } = [];
    }
}
