using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels.Extensions
{
    public static class CompanyListExtensions
    {
        public static IEnumerable<float> GetValues(this List<Price> prices)
        {
            return prices.Select(x => x.Value);
        }
    }
}
