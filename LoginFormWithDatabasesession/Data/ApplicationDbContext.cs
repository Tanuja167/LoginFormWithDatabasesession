using LoginFormWithDatabasesession.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginFormWithDatabasesession.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }

        public DbSet<User1> user1 { get; set; }
    }
}
