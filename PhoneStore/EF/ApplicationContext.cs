using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneStore.Models;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<PhoneStore.Models.Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<PhoneStore.Models.Phone> Phone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .HasMany(m => m.Phones)
                .WithOne(p => p.Manufacturer)
                .HasForeignKey(p => p.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
