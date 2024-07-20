using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Domain;

namespace VendManager.Persistence
{
    public class VendorManagerDbContext : DbContext
    {
        public VendorManagerDbContext(DbContextOptions<VendorManagerDbContext> options) : base(options) { }
        
        public DbSet<Machines> Machines { get; set; }
        public DbSet<Sensor> Sensor { get; set; }
        public DbSet<MachineGroups> MachineGroups { get; set; }
        public DbSet<SensorBar> SensorBar { get; set; }
        public DbSet<SensorValueHistory> SensorValueHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machines>().ToTable("Machines");
            modelBuilder.Entity<Sensor>().ToTable("Sensor");
            modelBuilder.Entity<MachineGroups>().ToTable("MachineGroups");
            modelBuilder.Entity<SensorBar>().ToTable("SensorBar");
            modelBuilder.Entity<SensorValueHistory>().ToTable("SensorValueHistory");

            // Configure the foreign key relationship
            modelBuilder.Entity<SensorBar>()
                .HasOne(sb => sb.Machine)
                .WithOne(m => m.SensorBars)
                
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
