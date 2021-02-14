using System.Collections.Generic;

namespace Services.DataService.SourceAccess
{
    public interface ISourceAccess<T> : ISourceAccess
    {
        T Get(string id);
        IEnumerable<T> GetAll(params string[] ids);
    }

    public interface ISourceAccess { }
}