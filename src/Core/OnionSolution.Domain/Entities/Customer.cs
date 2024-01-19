using OnionSolution.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Order> Orders { get; set; }

        public string DisplayName { get => $"{Name} {Surname}"; }
    }
}
