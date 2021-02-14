using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.PlotService
{
    public static class PlotFactory
    {
        static Type[] _types;
        static PlotFactory()
        {
            _types = Assembly.GetExecutingAssembly().GetTypes(); 
        }
        public static IPlot<T> Create<T>()
        {
            Type plotType = _types.Where(x => x.Name.Contains(typeof(T).Name) && x.Name.Contains("Plot")).FirstOrDefault();
            if(plotType == null)
            {
                throw new NotImplementedException($"type {typeof(T)} is not implemented in {nameof(PlotFactory)}");
            }
            return (IPlot<T>)Activator.CreateInstance(plotType);
        }
    }
}
