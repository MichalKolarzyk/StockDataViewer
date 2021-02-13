using BaseModels;
using Services.DataService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ISourceService _sourceService;
        public AddCompanyDialogViewModel(ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        public string Id
        {
            get { return _company.Id; }
            set
            {
                _company.Id = value;
                OnPropertyChanged(Id);
                UpdateCompany(Id);
            }
        }

        public string FullName
        {
            get { return _company.FullName; }
            set { 
                _company.FullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public float RegularMarketPrice => _company.RegularMarketPrice;

        public float MarketCup
        {
            get { return _company.MarketCup; }
            set
            {
                _company.MarketCup = value;
                OnPropertyChanged(nameof(MarketCup));
            }
        }
        public ObservableCollection<Price> Prices
        {
            get { return new ObservableCollection<Price>(_company.Prices); }
            set { 
                _company.Prices = value.ToList();
                OnPropertyChanged(nameof(Prices));
                OnPropertyChanged(nameof(RegularMarketPrice));
            }
        }

        private void UpdateCompany(string id)
        {
            Company result = _sourceService.Get<Company>(id);
            if (result != null)
            {
                FullName = result.FullName;
                MarketCup = result.MarketCup;
                Prices = new ObservableCollection<Price>(result.Prices);
            }
            else
            {
                FullName = "";
                MarketCup = default;
                Prices = new ObservableCollection<Price>();
            }
        }

        #region CreateCommand
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
            if (string.IsNullOrEmpty(Id)) return false;
            //if (string.IsNullOrEmpty(FullName)) return false;
            return true;
        }

        private void Create(object obj)
        {
            CloseDialogWithResult((IDialogWindow)obj, _company);
        }
        #endregion
    }
}
