using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PlotService
{
    class PlotService : IPlotService
    {
        public IPlot<T> GetPlotl<T>()
        {
            return PlotFactory.Create<T>();
        }
    }
}
