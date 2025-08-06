using Microsoft.EntityFrameworkCore;

namespace DockerTutorial.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Student> Students {  get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
