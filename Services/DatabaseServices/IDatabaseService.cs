using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DatabaseServices
{
    public interface IDatabaseService<T> : ISorceService<T>
    {
        event EventHandler OnDatabaseChange;
        void Add(T obj);
        void Remove(T obj);
    }
}
