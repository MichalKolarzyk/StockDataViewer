using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShedulerServices
{
    public interface IScheduleService
    {
        Task Start();
        Task Stop();
    }
}
