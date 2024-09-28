using Microsoft.EntityFrameworkCore;

namespace Philharmonic.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        :base(options)
        {
        }

       public DbSet<User> auths { get; set; } = null!;
    }
}
