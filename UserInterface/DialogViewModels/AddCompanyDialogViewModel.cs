using BaseModels;
using Services.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.Dialogs;
using UserInterface.Utilities;

namespace UserInterface.DialogViewModels
{
    public class AddCompanyDialogViewModel : DialogViewModelBase<Company>
    {
        Company _company = new Company();
        ISorceService<Company> _dataSource;
        public AddCompanyDialogViewModel(ISorceService<Company> dataSource)
        {
            _dataSource = dataSource;
        }
        public string Id
        {
            get { return _company.Id; }
            set 
            { 
                _company.Id = value;
                UpdateCompany();

            }
        }

        private void UpdateCompany()
        {
            Company dataCheckerResult = _dataSource.Get(Id).Result;
            if(dataCheckerResult != null)
            {
                FullName = dataCheckerResult.FullName;
                MarketCup = dataCheckerResult.MarketCup;
                _company.Prices = dataCheckerResult.Prices;
            }
            else
            {
                FullName = "";
                MarketCup = default;
                _company.Prices = new List<Price>();
            }
            OnPropertyChanged(nameof(RegularMarketPrice));
            OnPropertyChanged(Id);
        }

        public string FullName
        {
            get { return _company.FullName; }
            set { 
                _company.FullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public float RegularMarketPrice
        {
            get { return _company.RegularMarketPrice; }
            set
            {
                OnPropertyChanged(nameof(RegularMarketPrice));
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


        private ICommand _createCommand;
        public ICommand CreateCommand
        {
            get 
            {
                if (_createCommand == null) _createCommand = new RelayCommand(Create, CanCreate);
                return _createCommand; 
            }
        }

        private bool CanCreate(object arg)
        {
            if (string.IsNullOrEmpty(Id) == true) return false;
            if (string.IsNullOrEmpty(FullName) == true) return false;
            return true;
        }

        private void Create(object obj)
        {
            CloseDialogWithResult((IDialogWindow)obj, _company);
        }
    }
}
