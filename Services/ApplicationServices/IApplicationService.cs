using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ApplicationServices
{
    public interface IApplicationService
    {
        object SelectedObject { get; set; }

        event EventHandler OnSelectedObjectChange;
    }
}
