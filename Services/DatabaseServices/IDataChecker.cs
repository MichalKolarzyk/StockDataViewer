using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DatabaseServices
{
    public interface IDataChecker<T>
    {
        Task<bool> ExistAsync(T obj);
        bool Exist(T obj);
    }
}
