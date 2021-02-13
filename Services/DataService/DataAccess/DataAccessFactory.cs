using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataService.DataAccess
{
    public static class DataAccessFactory
    {
        public static Type[] _types;
        static DataAccessFactory()
        {
            _types = Assembly.GetExecutingAssembly().GetTypes();
        }
        public static IDataAccess<T> Create<T>()
        {
            Type type = _types.
                Where(
                x => x.FullName.Contains("DataAccess")
                && x.FullName.Contains(typeof(T).Name)).FirstOrDefault();
            if (type == null)
            {
                throw new NotImplementedException
                    ($"Type of {typeof(T)} is not implemented in {nameof(DataAccessFactory)}");
            }
            return (IDataAccess<T>)Activator.CreateInstance(type);
        }
    }
}
