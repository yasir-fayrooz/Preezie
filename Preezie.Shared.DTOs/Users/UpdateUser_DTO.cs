using System.ComponentModel.DataAnnotations;

namespace Preezie.Shared.DTOs.Users
{
    public class UpdateUser_DTO
    {
        public string DisplayName { get; set; }

        [RegularExpression("^$|(?=.{8})(?=.*[A-Z])(?=.*\\d)", ErrorMessage = "Passwords must be at least 8 characters long, with at least 1 uppercase character and 1 numeric digit.")]
        public string Password { get; set; }
    }
}