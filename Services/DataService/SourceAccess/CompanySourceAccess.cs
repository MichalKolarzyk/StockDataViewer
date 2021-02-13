using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace Services.DataService.SourceAccess
{
    class CompanySourceAccess : BaseSourceAccess<Company>
    {
        public IEnumerable<string> Symbols { get; set; }
        public IEnumerable<Field> Fields { get; set; }
        public CompanySourceAccess()
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

            Symbols = new List<string>
            {
                "K",
                "KOS",
                "KO"
            };
        }

        public override Company Get(string id)
        {
            try
            {
                var securities = Yahoo.Symbols(id).Fields(Fields.ToArray()).QueryAsync().Result;
                if (securities.Count == 0) return null;
                return CreateCompany(securities[id]);
            }
            catch
            {
                return null;
            }
        }

        public override IEnumerable<Company> GetAll(params string[] ids)
        {
            var securities = Yahoo.Symbols(Symbols.ToArray()).Fields(Fields.ToArray()).QueryAsync().Result;
            List<Company> output = new List<Company>();
            foreach (string symbol in Symbols)
            {
                output.Add(CreateCompany(securities[symbol]));
            }
            return output;
        }

        private Company CreateCompany(Security security) 
        {
            return new Company
            {
                Id = security.Symbol,
                Prices = new List<Price> { new Price { Value = (float)security.RegularMarketPrice, Date = DateTime.Now } },
                FullName = security.ShortName,
                MarketCup = security.MarketCap
            };
        }
    }
}
