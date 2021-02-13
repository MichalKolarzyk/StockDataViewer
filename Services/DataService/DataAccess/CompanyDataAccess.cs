using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataService.DataAccess
{
    public class CompanyDataAccess : IDataAccess<Company>
    {
        public void Add(Company obj)
        {
            throw new NotImplementedException();
        }

        public Company Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAll(params string[] ids)
        {
            List<Price> prices = new List<Price>()
            {
                new Price { Date=DateTime.Now, Value=1},
                new Price { Date = DateTime.Now, Value = 2 },
                new Price { Date = DateTime.Now, Value = 3 },
            };
            return new List<Company>
            {
                new Company {Id = "APPL", FullName="Apple", Prices = prices},
                new Company {Id = "KOS", FullName="Kosmos Energy"},
                new Company {Id = "MORD", FullName="Moderna"}
            };
        }

        public void Remove(Company obj)
        {
            throw new NotImplementedException();
        }
    }
}
