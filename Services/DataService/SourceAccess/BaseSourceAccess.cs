using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataService.SourceAccess
{
    public abstract class BaseSourceAccess<T> : ISourceAccess<T>
        where T: new()
    {
        private static T _instance = new T();
        public static T Instance => _instance;

        public abstract T Get(string id);
        public abstract IEnumerable<T> GetAll(params string[] ids);
    }
}
