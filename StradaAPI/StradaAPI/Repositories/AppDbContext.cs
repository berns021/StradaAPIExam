using Microsoft.EntityFrameworkCore;
using StradaAPI.Model;

namespace StradaAPI.Repositories
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employment> Employments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure SQLite database
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.FirstName).IsRequired();
                entity.Property(u => u.LastName).IsRequired();
                entity.Property(u => u.Email).IsRequired();
            });

            // Configure Address entity
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Street).IsRequired();
                entity.Property(a => a.City).IsRequired();
            });

            // Configure Employment entity
            modelBuilder.Entity<Employment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Company).IsRequired();
                entity.Property(e => e.MonthsOfExperience).IsRequired();
                entity.Property(e => e.Salary).IsRequired();
                entity.Property(e => e.StartDate).IsRequired();
            });
        }
    }


}

