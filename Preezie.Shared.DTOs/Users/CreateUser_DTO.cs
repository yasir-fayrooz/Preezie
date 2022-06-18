using System.ComponentModel.DataAnnotations;

namespace Preezie.Shared.DTOs.Users
{
    public class CreateUser_DTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must be a minimum of 8 characters long and contain at least 1 uppercase character and 1 numeric digit.")]
        public string Password { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}