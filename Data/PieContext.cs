using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Barna_Valentina_Proiect_Pies.Models;

namespace Barna_Valentina_Proiect_Pies.Data
{
    public class PieContext : DbContext
    {
        public PieContext(DbContextOptions<PieContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<RetailedPie> RetailedPies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Pie>().ToTable("Pie");
            modelBuilder.Entity<Retailer>().ToTable("Retailer");
            modelBuilder.Entity<RetailedPie>().ToTable("RetailedPie");
            modelBuilder.Entity<RetailedPie>()
            .HasKey(c => new { c.PieID, c.RetailerID });//configureaza cheia primara compusa
        }
    }
}
