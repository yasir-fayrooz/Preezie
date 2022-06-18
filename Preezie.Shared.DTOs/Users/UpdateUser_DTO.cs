using System.ComponentModel.DataAnnotations;

namespace Preezie.Shared.DTOs.Users
{
    public class UpdateUser_DTO
    {
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}