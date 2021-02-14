using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PlotService
{
    public interface IPlotService
    {
        IPlot<T> GetPlotl<T>();
    }
}
