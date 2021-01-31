using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Company : IStock
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public List<float> Values { get; set; }


        public override string ToString()
        {
            return $"{Id} {FullName}";
        }
    }
}
