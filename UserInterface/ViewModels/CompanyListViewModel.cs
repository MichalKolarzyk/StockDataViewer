using BaseModels;
using Services.ApplicationServices;
using Services.DataService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.Dialogs;
using UserInterface.DialogViewModels;
using UserInterface.Utilities;

namespace UserInterface.ViewModels
{
    public class CompanyListViewModel : BaseViewModel
    {
        IApplicationService _applicationService;
        IDialogService _dialogService;
        IDataService _dataService;
        AddCompanyDialogViewModel _addCompanyDialogViewModel;
        public CompanyListViewModel(
            IDialogService dialogService,
            IDataService dataService,
            IApplicationService applicationService,
            AddCompanyDialogViewModel addCompanyDialogViewModel)
        {
            _applicationService = applicationService;
            _dialogService = dialogService;
            _addCompanyDialogViewModel = addCompanyDialogViewModel;

            _dataService = dataService;

            UpdateCompanies();
        }

        private void UpdateCompanies()
        {
            Companies = new ObservableCollection<Company>(_dataService.GetAll<Company>());
        }

        private ObservableCollection<Company> _companies;
        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set 
            { 
                _companies = value;
                OnPropertyChanged(nameof(Companies));
            }
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get 
            {
                if (_addCommand == null) _addCommand = new RelayCommand(Add);
                return _addCommand; 
            }
        }

        private void Add(object obj)
        {
            Company company = _dialogService.OpenDialog(_addCompanyDialogViewModel);
            if(company != null)
            {
                _dataService.Add(company);
            }
        }

        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null) _removeCommand = new RelayCommand(Remove);
                return _removeCommand;
            }
        }

        private void Remove(object obj)
        {
            if(_applicationService.SelectedObject is Company company)
            {
                _dataService.Remove(company);
            }
        }

        public Company SelectedCompany 
        {
            get => (Company)_applicationService.SelectedObject;
            set => _applicationService.SelectedObject = value;
        }
    }
}
