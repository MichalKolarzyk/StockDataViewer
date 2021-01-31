using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    interface IStock
    {
        string Id { get; set; }
        List<float> Values { get; set; }
    }
}
