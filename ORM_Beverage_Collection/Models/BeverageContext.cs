using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORM_Beverage_Collection.Models
{
    public partial class BeverageContext : DbContext
    {
        public BeverageContext()
        {
        }

        public BeverageContext(DbContextOptions<BeverageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beverage> Beverages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=****************.net;Database=***************;User Id=***********;Password=**********;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beverage>(entity =>
            {
                entity.Property(e => e.Name).IsFixedLength();

                entity.Property(e => e.Pack).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
