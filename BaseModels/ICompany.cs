using System.Collections.Generic;

namespace BaseModels
{
    public interface ICompany : IStock
    {
        string FullName { get; set; }
        float MarketCup { get; set; }
        float RegularMarketPrice { get; }
    }
}