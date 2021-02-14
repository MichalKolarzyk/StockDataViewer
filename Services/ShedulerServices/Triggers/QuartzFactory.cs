using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShedulerServices
{
    public static class QuartzFactory
    {
        public static string Create(EnumQuartz enumQuartz)
        {
            switch (enumQuartz)
            {
                case EnumQuartz.EveryMinuteInWeek:
                    return "0 * * ? * MON-FRI";
                case EnumQuartz.Every5MinuteInWeek:
                    return "0 */5 * ? * MON-FRI";
                case EnumQuartz.EveryMinute:
                    return "0 * * ? * *";
                case EnumQuartz.Every5Minute:
                    return "0 */5 * ? * *";
            }
            throw new NotImplementedException($"{enumQuartz} is not implemented in {nameof(QuartzFactory)}");
        }
    }
}
