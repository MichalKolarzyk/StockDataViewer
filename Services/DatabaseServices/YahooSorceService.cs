using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YahooFinanceApi;
using System.Threading.Tasks;

namespace Services.DatabaseServices
{
    public class YahooSorceService : ISorceService<Company>
    {
        public IEnumerable<string> Symbols { get; set; }
        public IEnumerable<Field> Fields { get; set; }

        public YahooSorceService()
        {
            Fields = new List<Field>
            {
                Field.Symbol,
                Field.RegularMarketPrice,
                Field.ShortName,
                Field.Currency,
                Field.MarketCap,
                Field.RegularMarketChange,
                Field.RegularMarketVolume,
                Field.Ask
            };
        }
        public async Task<IEnumerable<Company>> GetAll()
        {
            var securities = await Yahoo.Symbols(Symbols.ToArray()).Fields(Fields.ToArray()).QueryAsync();
            List<Company> output = new List<Company>();
            foreach(string symbol in Symbols)
            {
                output.Add(new Company
                {
                    Id = securities[symbol].Symbol,
                    Prices = new List<Price> { new Price { Value = (float)securities[symbol].RegularMarketPrice, Date=DateTime.Now} },
                    FullName = securities[symbol].ShortName,
                    MarketCup = securities[symbol].MarketCap
                });
            }
            return output;
        }

        public async Task<Company> Get(string id)
        {
            try
            {
                var securities = Yahoo.Symbols(id).Fields(Fields.ToArray()).QueryAsync().Result;
                if (securities.Count == 0) return null;
                return new Company
                {
                    Id = securities[id].Symbol,
                    Prices = new List<Price> { new Price { Value = (float)securities[id].RegularMarketPrice, Date = DateTime.Now } },
                    FullName = securities[id].ShortName,
                    MarketCup = securities[id].MarketCap
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
