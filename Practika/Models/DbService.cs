using Microsoft.EntityFrameworkCore;
using Practika.Models;

namespace Practika.Data // ← PascalCase recommended
{
    public class DbService : DbContext
    {
        public DbSet<action_logs> action_logs { get; set; }
        public DbSet<body_type> body_type { get; set; }
        public DbSet<brands> brands { get; set; }
        public DbSet<cars> cars { get; set; }
        public DbSet<car_images> car_images { get; set; }
        public DbSet<categories> categories { get; set; }
        public DbSet<color> color { get; set; }
        public DbSet<engine_type> engine_type { get; set; }
        public DbSet<favorites> favorites { get; set; }
        public DbSet<messages> messages { get; set; }
        public DbSet<models> models { get; set; }
        public DbSet<orders> orders { get; set; }
        public DbSet<reviews> reviews { get; set; }
        public DbSet<roles> roles { get; set; }
        public DbSet<status> status { get; set; }
        public DbSet<transmission> transmissions { get; set; }
        public DbSet<users> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                "Server=tompsons.beget.tech;" +
                "Port=3306;" +
                "Database=tompsons_stud10;" +
                "Uid=tompsons_stud10;" +
                "Pwd=8Y9jVNB9cf;" +
                "Connection Timeout=30;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicitly map entity class names to table names (optional but safe)
            modelBuilder.Entity<action_logs>().ToTable("action_logs");
            modelBuilder.Entity<body_type>().ToTable("body_type");
            modelBuilder.Entity<brands>().ToTable("brands");
            modelBuilder.Entity<cars>().ToTable("cars");
            modelBuilder.Entity<car_images>().ToTable("car_images");
            modelBuilder.Entity<categories>().ToTable("categories");
            modelBuilder.Entity<color>().ToTable("color");
            modelBuilder.Entity<engine_type>().ToTable("engine_type");
            modelBuilder.Entity<favorites>().ToTable("favorites");
            modelBuilder.Entity<messages>().ToTable("messages");
            modelBuilder.Entity<models>().ToTable("models");
            modelBuilder.Entity<orders>().ToTable("orders");
            modelBuilder.Entity<reviews>().ToTable("reviews");
            modelBuilder.Entity<roles>().ToTable("roles");
            modelBuilder.Entity<status>().ToTable("status");
            modelBuilder.Entity<transmission>().ToTable("transmission");
            modelBuilder.Entity<users>().ToTable("users");
        }
    }
}