using BaseModels;
using Services.ApplicationServices;
using Services.DatabaseServices;
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
        IDatabaseService<Company> _companyDatabaseService;
        IApplicationService _applicationService;
        IDialogService _dialogService;
        AddCompanyDialogViewModel _addCompanyDialogViewModel;
        public CompanyListViewModel(
            IDatabaseService<Company> companyDatabaseService, 
            IDialogService dialogService,
            IApplicationService applicationService,
            AddCompanyDialogViewModel addCompanyDialogViewModel)
        {
            _applicationService = applicationService;
            _dialogService = dialogService;
            _addCompanyDialogViewModel = addCompanyDialogViewModel;

            _companyDatabaseService = companyDatabaseService;
            _companyDatabaseService.OnDatabaseChange += UpdateCompanies;

            Companies = new ObservableCollection<Company>(_companyDatabaseService.GetAll());
        }

        private void UpdateCompanies(object sender, EventArgs e)
        {
            Companies = new ObservableCollection<Company>(_companyDatabaseService.GetAll());
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
                _companyDatabaseService.Add(company);
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
                _companyDatabaseService.Remove(company);
            }
        }

        public Company SelectedCompany 
        {
            get => (Company)_applicationService.SelectedObject;
            set => _applicationService.SelectedObject = value;
        }
    }
}
