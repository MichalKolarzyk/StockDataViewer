using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SessionService
{
    class SessionService : ISessionService
    {
        public Session Session { get; set; } = new Session();

        public SessionService()
        {
            List<Price> prices = new List<Price>()
            {
                new Price { Date=new DateTime(2020,1,1), Value=1},
                new Price { Date = new DateTime(2020,1,2), Value = 5 },
                new Price { Date = new DateTime(2020,1,3), Value = 3 },
            };
            Session.Companies = new List<Company>
            {
                new Company {Id = "APPL", FullName="Apple", Prices = prices},
                new Company {Id = "KOS", FullName="Kosmos Energy"},
                new Company {Id = "MORD", FullName="Moderna"}
            };
        }
    }
}
