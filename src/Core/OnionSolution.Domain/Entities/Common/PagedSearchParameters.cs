using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Domain.Entities.Common
{
    public record PagedSearchParameters(int PageSize, int PageNumber, bool IsTracking);
}
