using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VehicleApi.Models;

namespace VehicleApi.Context
{
    public class VehicleApiDbContext : DbContext
    {
        public VehicleApiDbContext(DbContextOptions<VehicleApiDbContext> options)
     : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }


        //Setting up a primary key
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasKey(x => x.Id);
        }
    }
}
