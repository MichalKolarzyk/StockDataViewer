using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SessionService
{
    public interface ISessionService
    {
        Session Session { get; set; }
    }
}
