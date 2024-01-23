using OnionSolution.Domain.Entities.Common;
using OnionSolution.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
