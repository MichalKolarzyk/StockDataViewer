using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer
{
    public class StockAnalyzer : IStockAnalyzer
    {
        public StockRating Analyze(IStock stock, EnumStockAlgorithms enumStockAlgorithms)
        {
            return StockAlgorithmFactory.Create(enumStockAlgorithms).Evaluate(stock);
        }
    }
}
