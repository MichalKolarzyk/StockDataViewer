using Services.DataService.SourceAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataService.DataAccess
{
    public interface IDataAccess<T> : ISourceAccess<T>
    {
        void Add(T obj);
        void Remove(T obj);
    }
}
