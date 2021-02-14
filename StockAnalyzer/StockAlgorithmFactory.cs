using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer
{
    public static class StockAlgorithmFactory
    {
        static Type[] _types;
        static StockAlgorithmFactory()
        {
            _types = Assembly.GetExecutingAssembly().GetTypes();
        }
        public static IStockAlgorithm Create(EnumStockAlgorithms enumStockAlgorithms)
        {
            Type algorithmType = _types.Where(t => t.Name.Contains(enumStockAlgorithms.ToString())).FirstOrDefault();
            if(algorithmType == null)
            {
                throw new NotImplementedException
                    ($"Algorithm {enumStockAlgorithms} is not implemented in {nameof(StockAlgorithmFactory)}");
            }
            return (IStockAlgorithm)Activator.CreateInstance(algorithmType);
        }
    }
}
