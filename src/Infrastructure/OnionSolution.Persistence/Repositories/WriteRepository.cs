using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionSolution.Application.Repositories;
using OnionSolution.Domain.Entities.Common;
using OnionSolution.Persistence.Contexts;

namespace OnionSolution.Persistence.Repositories
{
    public class WriteRepository<T>(OnionSolutionEFDbContext context) : IWriteRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table => context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await context.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(IList<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool DeleteRange(IList<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            T data = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return Delete(data);
        }

        public bool Update(T model)
        {
            var entityEntiry = Table.Update(model);
            return entityEntiry.State == EntityState.Modified;
        }


        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }


    }
}
