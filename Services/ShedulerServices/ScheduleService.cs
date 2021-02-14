using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShedulerServices
{
    public class ScheduleService : IScheduleService
    {
        StdSchedulerFactory factory = new StdSchedulerFactory();
        IScheduler _scheduler;

        public void ScheduleJob(Action action, EnumQuartz enumQuartz)
        {
            string quartzExpression = QuartzFactory.Create(enumQuartz);
            ITrigger trigger = QuartzTriggersFactory.Create(quartzExpression);
            JobDataMap jobDataMap = new JobDataMap();
            jobDataMap.Add(jobDataMap.Count.ToString(), action);
            IJobDetail jobDetail = JobBuilder.Create<BaseJob>().UsingJobData(jobDataMap).Build();
            _scheduler.ScheduleJob(jobDetail, trigger);
        }

        public async Task Start()
        {
            if (_scheduler == null) _scheduler = await factory.GetScheduler();
            await _scheduler.Start();
        }

        public async Task Stop()
        {
            await _scheduler.Shutdown();
        }
    }
}
