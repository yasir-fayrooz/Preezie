namespace Preezie.Shared.DTOs.Users
{
    public class UserQuery_DTO
    {
        public string? ColumnName { get; set; }
        public string? Filter { get; set; }
        public bool Sort { get; set; }

        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 0;
    }
}