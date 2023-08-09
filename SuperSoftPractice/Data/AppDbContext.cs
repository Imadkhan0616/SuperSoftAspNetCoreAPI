using Microsoft.EntityFrameworkCore;
using SuperSoftPractice.Model;

namespace ApplicationDatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClassModel> ClassModel { get; set; } = default!;

        public DbSet<StudentModel> StudentModel { get; set; } = default!;

        public DbSet<SuperSoftPractice.Model.SectionModel> SectionModel { get; set; }
    }
}
