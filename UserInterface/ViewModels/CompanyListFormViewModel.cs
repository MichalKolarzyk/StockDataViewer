using AutoMapper;
using BaseModels;
using Services.ApplicationServices;
using Services.DataService;
using Services.SessionService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.Dialogs;
using UserInterface.DialogViewModels;
using UserInterface.Models;
using UserInterface.Utilities;

namespace UserInterface.ViewModels
{
    public class CompanyListFormViewModel : BaseViewModel
    {
        IApplicationService _applicationService;
        IDialogService _dialogService;
        IDataService _dataService;
        ISessionService _sessionService;
        IMapper _mapper;
        AddCompanyDialogViewModel _addCompanyDialogViewModel;

        public SessionViewModel SessionViewModel { get; set; }

        public CompanyListFormViewModel(
            IDialogService dialogService,
            IDataService dataService,
            ISessionService sessionService,
            IApplicationService applicationService,
            IMapper mapper,
            AddCompanyDialogViewModel addCompanyDialogViewModel)
        {
            _applicationService = applicationService;
            _dialogService = dialogService;
            _addCompanyDialogViewModel = addCompanyDialogViewModel;

            _sessionService = sessionService;
            _dataService = dataService;
            _mapper = mapper;

            SessionViewModel = _mapper.Map<SessionViewModel>(_sessionService.Session);
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

        public CompanyViewModel SelectedCompany 
        {
            get => (CompanyViewModel)_applicationService.SelectedObject;
            set => _applicationService.SelectedObject = value;
        }
    }
}
