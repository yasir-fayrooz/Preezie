using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Preezie.Shared.DTOs.Users
{
    public class UserQuery_DTO
    {
        [FromQuery]
        public string ColumnName { get; set; }
        [FromQuery]
        public string Filter { get; set; }
        [FromQuery]
        public bool Sort { get; set; }
    }
}