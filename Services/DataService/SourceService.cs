using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataService
{
    public class SourceService : ISourceService
    {
        public T Get<T>(string id)
        {
            return SourceAccessFactory.Create<T>().Get(id);
        }

        public IEnumerable<T> GetAll<T>()
        {
            return SourceAccessFactory.Create<T>().GetAll();
        }
    }
}
