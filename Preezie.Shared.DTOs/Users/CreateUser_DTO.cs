using System.ComponentModel.DataAnnotations;

namespace Preezie.Shared.DTOs.Users
{
    public class CreateUser_DTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.{8})(?=.*[A-Z])(?=.*\\d)", ErrorMessage = "Passwords must be at least 8 characters long, with at least 1 uppercase character and 1 numeric digit.")]
        public string Password { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}