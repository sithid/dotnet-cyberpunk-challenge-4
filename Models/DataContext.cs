using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_cyberpunk_challenge_4.Models.Arasaka;
using Microsoft.EntityFrameworkCore;

namespace dotnet_cyberpunk_challenge_4.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ArasakaCluster> arasakaClusters { get; set; } = null!;
        public DbSet<ArasakaDevice> arasakaDevices { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ArasakaCluster and ArasakaDevice relationships (same as before)
            modelBuilder.Entity<ArasakaDevice>()
                .HasOne(d => d.cluster)
                .WithMany(c => c.devices)
                .HasForeignKey(d => d.clusterId)
                .OnDelete(DeleteBehavior.Cascade);


            // Ensure IDs are auto-incrementing
            modelBuilder.Entity<ArasakaCluster>()
                .Property(c => c.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ArasakaDevice>()
                .Property(d => d.id)
                .ValueGeneratedOnAdd();
        }
    }
}