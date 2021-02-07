using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShedulerServices
{
    public static class QuartzTriggersFactory
    {
        public static ITrigger Create(string quartzExpressing)
        {
            return TriggerBuilder.Create()
                .WithCronSchedule(quartzExpressing)
                .StartNow()
                .Build();
        }
    }
}
