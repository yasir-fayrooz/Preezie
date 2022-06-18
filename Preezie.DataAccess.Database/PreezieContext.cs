using Microsoft.EntityFrameworkCore;
using Preezie.DataAccess.Models.User;

namespace Preezie.DataAccess.Database
{
    public class PreezieContext : DbContext
    {
        public PreezieContext(DbContextOptions<PreezieContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}