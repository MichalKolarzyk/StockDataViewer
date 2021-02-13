using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataService
{
    public interface ISourceService
    {
        IEnumerable<T> GetAll<T>();
        T Get<T>(string id);
    }
}
