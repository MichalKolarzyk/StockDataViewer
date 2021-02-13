using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataService
{
    public interface IDataService : ISourceService
    {
        void Add<T>(T obj);
        void Remove<T>(T obj);
    }
}
