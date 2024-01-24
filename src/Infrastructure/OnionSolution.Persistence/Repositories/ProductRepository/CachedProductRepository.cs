using Microsoft.Extensions.Caching.Distributed;
using OnionSolution.Application.Repositories.ProductRepository;
using OnionSolution.Domain.Entities.Products;
using OnionSolution.Persistence.Extensions;

namespace OnionSolution.Persistence.Repositories.ProductRepository
{
    public class CachedProductRepository(
        IProductReadRepository productReadRepository,
        IDistributedCache distributedCache) : ICachedProductRepository
    {
        public Task Add(Product product, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetByIdAsync(string guid, CancellationToken cancellationToken = default)
        {
            string key = $"product-{guid}";

            string? cachedProduct = await distributedCache.GetStringAsync(key, cancellationToken);

            Product? product;

            if (cachedProduct.IsNullOrEmptyOrWhiteSpace())
            {
                product = await productReadRepository.GetByIdAsync(guid, false, cancellationToken);

                if (product is not null)
                {
                    await distributedCache.SetStringAsync(key, product.Serialize(), cancellationToken);
                }
            }
            else
            {
                product = cachedProduct?.Deserialize<Product>();
            }

            return product;
        }

        public Task<bool> IsStockExist(string guid, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
