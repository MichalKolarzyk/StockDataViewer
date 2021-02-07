using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace Services.DatabaseServices
{
    public class YahooDataChecker : IDataChecker<Company>
    {
        public bool Exist(Company obj)
        {
            try
            {
                var securities = Yahoo.Symbols(obj.Id).Fields(Field.Symbol).QueryAsync();
                Task.WaitAll(securities);
                if (securities.Result.Count == 0) return false;
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async Task<bool> ExistAsync(Company obj)
        {
            try
            {
                var securities = await Yahoo.Symbols(obj.Id).Fields(Field.Symbol).QueryAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
