using BaseModels;
using Services.DataService.DataAccess;
using Services.DataService.SourceAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataService
{
    public static class SourceAccessFactory
    {
        public static Type[] _types;
        static Dictionary<Type, ISourceAccess> _sourceAccesInstances;
        static SourceAccessFactory()
        {
            _types = Assembly.GetExecutingAssembly().GetTypes();
            _sourceAccesInstances = new Dictionary<Type, ISourceAccess>();
        }
        public static ISourceAccess<T> Create<T>()
        {
            Type type = _types.
                Where(
                x => x.FullName.Contains("SourceAccess")
                && x.FullName.Contains(typeof(T).Name)).FirstOrDefault();
            if(type == null)
            {
                throw new NotImplementedException
                    ($"Type of {typeof(T)} is not implemented in {nameof(SourceAccessFactory)}");
            }
            if (_sourceAccesInstances.ContainsKey(type))
            {
                return (ISourceAccess<T>)_sourceAccesInstances[type];
            }
            ISourceAccess<T> sourceAccess = (ISourceAccess<T>)Activator.CreateInstance(type);
            _sourceAccesInstances.Add(type, sourceAccess);
            return sourceAccess;
        }
    }
}
