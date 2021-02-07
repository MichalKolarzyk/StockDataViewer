using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DatabaseServices
{
    public class CompaniesDatabaseService : IDatabaseService<Company>
    {
        List<Company> _companies;
        public CompaniesDatabaseService()
        {
            List<Price> prices = new List<Price>()
            {
                new Price { Date=DateTime.Now, Value=1},
                new Price { Date = DateTime.Now, Value = 2 },
                new Price { Date = DateTime.Now, Value = 3 },
            };
            _companies = new List<Company>
            {
                new Company {Id = "APPL", FullName="Apple", Prices = prices},
                new Company {Id = "KOS", FullName="Kosmos Energy"},
                new Company {Id = "MORD", FullName="Moderna"}
            };
        }

        public event EventHandler OnDatabaseChange;

        public void Add(Company obj)
        {
            _companies.Add(obj);
            OnDatabaseChange?.Invoke(this, null);
        }

        public void Remove(Company obj)
        {
            _companies.Remove(obj);
            OnDatabaseChange?.Invoke(this, null);
        }

        async Task<IEnumerable<Company>> ISorceService<Company>.GetAll()
        {
            return _companies;
        }
    }
}
