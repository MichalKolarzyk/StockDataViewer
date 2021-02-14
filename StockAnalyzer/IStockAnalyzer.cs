using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer
{
    public interface IStockAnalyzer
    {
        StockRating Analyze(IStock stock, EnumStockAlgorithms enumStockAlgorithms);
    }
}
