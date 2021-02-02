using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShedulerServices
{
    public class SchedulerService : IScheduleService
    {
        StdSchedulerFactory factory = new StdSchedulerFactory();
        IScheduler _scheduler;
        Dictionary<Action, ITrigger> _tasks;


        public async Task Start()
        {
            JobBuilder.Create<BaseJob>().SetJobData(new JobDataMap());
        }

        public async Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
