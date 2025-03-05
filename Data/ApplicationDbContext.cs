using Microsoft.EntityFrameworkCore;
using WebApplicationRazor.Modelos;

namespace WebApplicationRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Curso> Curso { get; set; }
    }
}
