using System.ComponentModel.DataAnnotations;

namespace Preezie.DataAccess.Models.User
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }
}