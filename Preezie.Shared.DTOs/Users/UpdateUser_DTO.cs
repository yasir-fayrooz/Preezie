using System.ComponentModel.DataAnnotations;

namespace Preezie.Shared.DTOs.Users
{
    public class UserUpdate_DTO
    {
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}