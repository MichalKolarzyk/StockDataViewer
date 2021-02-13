using BaseModels;
using Services.DataService.DataAccess;
using Services.DataService.SourceAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataService
{
    public class DataService : IDataService
    {
        public void Add<T>(T obj)
        {
            DataAccessFactory.Create<T>().Add(obj);
        }

        public T Get<T>(string id)
        {
            return DataAccessFactory.Create<T>().Get(id);
        }

        public IEnumerable<T> GetAll<T>()
        {
            return DataAccessFactory.Create<T>().GetAll();
        }
        public void Remove<T>(T obj)
        {
            DataAccessFactory.Create<T>().Remove(obj);
        }
    }
}
