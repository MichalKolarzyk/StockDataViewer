using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShedulerServices
{
    public interface IScheduleService
    {
        void ScheduleJob(Action action, EnumQuartz enumQuartz);
        Task Start();
        Task Stop();
    }
}
