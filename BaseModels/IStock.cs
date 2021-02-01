using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public interface IStock
    {
        string Id { get; set; }
        List<Price> Prices { get; set; }
    }
}
