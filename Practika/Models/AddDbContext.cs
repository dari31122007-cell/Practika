using Microsoft.EntityFrameworkCore;

namespace Practika.Models
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ActionLog> ActionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.IdRoles);
                entity.Property(r => r.IdRoles).HasColumnName("id_roles");
                entity.ToTable("roles");
            });

            modelBuilder.Entity<ActionLog>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).HasColumnName("is");
                entity.ToTable("action_logs");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=tompsons_stud10;user=root;password=;",
                ServerVersion.AutoDetect("server=localhost;port=3306;database=tompsons_stud10;user=root;password=;")
            );
        }
    }
}