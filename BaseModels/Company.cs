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
        public float RegularMarketPrice {
            get 
            {
                if (Prices.Count == 0) return default;
                return Prices[0].Value;
            } 
        }
        public float MarketCup { get; set; }
        public List<Price> Prices { get; set; } = new List<Price>();


        public override string ToString()
        {
            return $"{Id} {FullName}";
        }
    }
}
