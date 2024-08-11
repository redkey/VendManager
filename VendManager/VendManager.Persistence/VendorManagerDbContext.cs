using Microsoft.EntityFrameworkCore;
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



            // Configure SensorBar entity
            modelBuilder.Entity<SensorBar>(entity =>
            {
                entity.ToTable("SensorBar");

                // Configure properties
                entity.Property(e => e.MacAddress).IsRequired().HasMaxLength(50);
                entity.Property(e => e.FirmwareVersion).HasMaxLength(50);

                // Configure relationships
                entity.HasOne(sb => sb.Machine)
                   .WithMany(m => m.SensorBars)
                   .HasForeignKey(sb => sb.MachineID)
                   .OnDelete(DeleteBehavior.Restrict);
            });


            // Configure Sensor entity
            modelBuilder.Entity<Sensor>()
                .ToTable("Sensor")
                .HasOne(s => s.SensorBar)
                .WithMany(sb => sb.Sensors)
                .HasForeignKey(s => s.SensorBarID);
         
        }
    }
}
