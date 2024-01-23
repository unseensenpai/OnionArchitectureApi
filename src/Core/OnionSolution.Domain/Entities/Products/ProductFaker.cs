using Bogus;

namespace OnionSolution.Domain.Entities.Products
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Stock, f => f.Finance.Random.Int(1, 50000));
            RuleFor(p => p.Price, f => f.Finance.Random.Float(1, 1000000));
        }

    }
}
