using Microsoft.EntityFrameworkCore;
using StudentResultApp.Models;

namespace StudentResultApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Module> Modules => Set<Module>();

        public DbSet<Student> Students => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Modules");
                entity.HasKey(m => m.Id);
                entity.HasIndex(m => m.Code).IsUnique();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("StudentResults");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Module).HasColumnName("ModuleCode");
                entity.HasIndex(s => s.StudentNumber).IsUnique();
            });
        }
    }
}
