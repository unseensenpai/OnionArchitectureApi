using Microsoft.EntityFrameworkCore;
using OnionSolution.Application.Repositories;
using OnionSolution.Domain.Entities.Common;
using OnionSolution.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Persistence.Repositories
{
    public class ReadRepository<T>(OnionSolutionEFDbContext context) : IReadRepository<T> where T : BaseEntity
    {

        public DbSet<T> Table => context.Set<T>();

        public IQueryable<T> GetAll() 
            => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression) 
            => Table.Where(expression);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression) 
            => await Table.FirstOrDefaultAsync(expression);


        public async Task<T> GetByIdAsync(string id) 
            => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));


    }
}
