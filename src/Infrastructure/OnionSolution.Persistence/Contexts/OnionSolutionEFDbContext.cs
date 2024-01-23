using Microsoft.EntityFrameworkCore;
using OnionSolution.Domain.Entities;
using OnionSolution.Domain.Entities.Common;
using OnionSolution.Domain.Entities.Products;
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var baseEntity in ChangeTracker.Entries<BaseEntity>())
            {
                switch (baseEntity.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        baseEntity.Entity.UpdateDate = DateTime.UtcNow.AddHours(3);
                        break;
                    case EntityState.Added:
                        baseEntity.Entity.CreateDate = DateTime.UtcNow.AddHours(3);
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
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
