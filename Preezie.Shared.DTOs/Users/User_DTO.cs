using System.ComponentModel.DataAnnotations;

namespace Preezie.Shared.DTOs.Users
{
    public class User_DTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}