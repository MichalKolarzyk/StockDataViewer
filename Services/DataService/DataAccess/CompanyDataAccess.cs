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
        List<Company> _companies;
        public CompanyDataAccess()
        {
            List<Price> prices = new List<Price>()
            {
                new Price { Date=new DateTime(2020,1,1), Value=1},
                new Price { Date = new DateTime(2020,1,2), Value = 5 },
                new Price { Date = new DateTime(2020,1,3), Value = 3 },
            };
            _companies = new List<Company>
            {
                new Company {Id = "APPL", FullName="Apple", Prices = prices},
                new Company {Id = "KOS", FullName="Kosmos Energy"},
                new Company {Id = "MORD", FullName="Moderna"}
            };
        }

        public event EventHandler OnDataAccessChange;

        public void Add(Company obj)
        {
            _companies.Add(obj);
            OnDataAccessChange?.Invoke(this, null);
        }

        public Company Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAll(params string[] ids)
        {
            return _companies;
        }

        public void Remove(Company obj)
        {
            _companies.Remove(obj);
            OnDataAccessChange?.Invoke(this, null);
        }
    }
}
