using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Persistence.Contexts
{
    public class OnionSolutionEFContext : DbContext
    {
        public OnionSolutionEFContext(DbContextOptions options) : base(options)
        {
        }

        protected OnionSolutionEFContext()
        {
        }
    }
}
