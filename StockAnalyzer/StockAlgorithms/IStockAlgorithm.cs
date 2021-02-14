using BaseModels;

namespace StockAnalyzer
{
    public interface IStockAlgorithm
    {
        StockRating Evaluate(IStock stock);
    }
}