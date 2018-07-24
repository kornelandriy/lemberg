using Microsoft.EntityFrameworkCore;

namespace lemberg.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .HasOne(p => p.Mark)
                .WithOne(b => b.People)
                .HasForeignKey<Mark>(b => b.Id);

            modelBuilder.Entity<People>()
                .HasIndex(u => new {u.FirstName, u.LastName})
                .IsUnique();
        }
    }
}