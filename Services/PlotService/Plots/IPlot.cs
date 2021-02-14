using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PlotService
{
    public interface IPlot<T>
    {
        PlotModel GetModel(IEnumerable<T> data);
    }
}
