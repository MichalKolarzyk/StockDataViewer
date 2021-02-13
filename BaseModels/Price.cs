using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Price : IPrice
    {
        public float Value { get; set; }
        public DateTime Date { get; set; }
    }
}
