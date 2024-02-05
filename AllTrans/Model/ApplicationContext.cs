using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AllTrans.Model
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<FavoriteTransport> FavoriteTransport { get; set; }
        public DbSet<StopRoute> StopsRoute { get; set; }
        public DbSet<StopTime> StopsTime { get; set; }
        public DbSet<TransRoute> TransRoute { get; set; }
        public DbSet<Transport> Transport { get; set; }

        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2LAR9DR;Database=KursovoiProektBD;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}
