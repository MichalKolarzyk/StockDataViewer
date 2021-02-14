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
        static Dictionary<Type, IDataAccess> _sourceAccesInstances;
        static DataAccessFactory()
        {
            _types = Assembly.GetExecutingAssembly().GetTypes();
            _sourceAccesInstances = new Dictionary<Type, IDataAccess>();
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
            if (_sourceAccesInstances.ContainsKey(type))
            {
                return (IDataAccess<T>)_sourceAccesInstances[type];
            }
            IDataAccess<T> sourceAccess = (IDataAccess<T>)Activator.CreateInstance(type);
            _sourceAccesInstances.Add(type, sourceAccess);
            return sourceAccess;
        }
    }
}
