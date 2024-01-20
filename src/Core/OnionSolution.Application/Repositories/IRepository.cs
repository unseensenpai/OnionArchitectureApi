using Microsoft.EntityFrameworkCore;
using OnionSolution.Domain.Entities.Common;

namespace OnionSolution.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
