using OnionSolution.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(IList<T> models);
        bool Delete(T model);
        bool DeleteRange(IList<T> models);
        Task<bool> DeleteAsync(string id);
        bool Update(T model);

        Task<int> SaveAsync();
    }
}
