using Microsoft.EntityFrameworkCore;
using OnionSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Persistence.Contexts
{
    public class OnionSolutionEFDbContext : DbContext
    {
        private const string SCHEME = "ecom";

        public OnionSolutionEFDbContext(DbContextOptions options) : base(options)
        {
        }

        protected OnionSolutionEFDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SCHEME);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
