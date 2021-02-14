using BaseModels;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PlotService
{
    public class PricePlot : IPlot<Price>
    {
        PlotModel _plotModel;
        public PricePlot()
        {
            _plotModel = new PlotModel();
            _plotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd/MM", Title = "Date" });
            _plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Value" });
        }
        public PlotModel GetModel(IEnumerable<Price> data)
        {
            LineSeries series = new LineSeries();
            foreach (Price price in data)
            {
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(price.Date), price.Value));
            }
            _plotModel.Series.Add(series);
            return _plotModel;
        }
    }
}
