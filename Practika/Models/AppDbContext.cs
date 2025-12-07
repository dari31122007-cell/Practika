using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    internal class AppDbContext : DbContext
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
            optionsBuilder.UseSqlServer
            (
            @"Server=(localdb)\mssqllocaldb;Database=tompsons_stud10;Trusted_Connection=True;"
            );
        }
    }
}
