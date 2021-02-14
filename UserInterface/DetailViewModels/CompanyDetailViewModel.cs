using BaseModels;
using BaseModels.Extensions;
using OxyPlot;
using Services.ApplicationServices;
using Services.PlotService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Utilities;

namespace UserInterface.DetailViewModels
{
    public class CompanyDetailViewModel : BaseViewModel
    {
        IApplicationService _applicationService;
        IPlotService _plotService;
        public CompanyDetailViewModel(IApplicationService applicationService, IPlotService plotService)
        {
            _applicationService = applicationService;
            _applicationService.OnSelectedObjectChange += _applicationService_OnSelectedObjectChange;
            _plotService = plotService;
        }

        private void _applicationService_OnSelectedObjectChange(object sender, EventArgs e)
        {
            if (_applicationService.SelectedObject is Company company)
            {
                _company = company;
                Prices = new ObservableCollection<Price>(_company.Prices);
                OnPropertyChanged(nameof(Id));
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(Prices));
            }
        }

        private Company _company = new Company();
        public string Id
        {
            get { return _company.Id; }
            set
            {
                _company.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string FullName
        {
            get { return _company.FullName; }
            set 
            {
                _company.FullName = value; 
                OnPropertyChanged(nameof(FullName));
            }
        }

        public float MarketCup
        {
            get { return _company.MarketCup; }
            set
            {
                _company.MarketCup = value;
                OnPropertyChanged(nameof(MarketCup));
            }
        }

        public float RegularMarketPrice
        {
            get { return _company.RegularMarketPrice; }
        }

        private ObservableCollection<Price> _prices;
        public ObservableCollection<Price> Prices
        {
            get { return _prices; }
            set 
            { 
                _prices = value;
                OnPropertyChanged(nameof(Prices));
                OnPropertyChanged(nameof(RegularMarketPrice));
                OnPropertyChanged(nameof(PlotModel));
            }
        }

        public PlotModel PlotModel
        {
            get { return _plotService.GetPlotl<Price>().GetModel(Prices); }
        }

    }
}
