using OnionSolution.Domain.Entities.Products;
using System;

namespace OnionSolution.Application.Repositories.ProductRepository
{
    public interface ICachedProductRepository
    {
        Task<Product?> GetByIdAsync(string guid, CancellationToken cancellationToken = default);
        Task<bool> IsStockExist(string guid, CancellationToken cancellationToken = default);
        Task Add(Product product, CancellationToken cancellationToken = default);
        Task Update(Product product, CancellationToken cancellationToken = default);
    }
}
