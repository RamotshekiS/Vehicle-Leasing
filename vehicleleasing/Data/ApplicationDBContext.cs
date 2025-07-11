using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vehicleleasing.Models;

namespace vehicleleasing.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }


        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        // modelBuilder.Entity<Vehicle>()
        //     .HasOne(v => v.Supplier)
        //     .WithMany()
        //     .HasForeignKey(v => v.SupplierId)
        //     .IsRequired(false);  // Optional relationship

        // modelBuilder.Entity<Vehicle>()
        //     .HasOne(v => v.Branch)
        //     .WithMany()
        //     .HasForeignKey(v => v.BranchId)
        //     .IsRequired(false);

        // modelBuilder.Entity<Vehicle>()
        //     .HasOne(v => v.Client)
        //     .WithMany()
        //     .HasForeignKey(v => v.ClientId)
        //     .IsRequired(false);


        // modelBuilder.Entity<Vehicle>()
        //     .HasOne(v => v.Driver)
        //     .WithMany()
        //     .HasForeignKey(v => v.DriverId)
        //     .IsRequired(false);
            

        // }
        

    }
}