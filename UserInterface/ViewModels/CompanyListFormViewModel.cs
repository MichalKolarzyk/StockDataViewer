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
        IDialogService _dialogService;
        IMapper _mapper;
        AddCompanyDialogViewModel _addCompanyDialogViewModel;

        public SessionViewModel SessionViewModel { get; set; }

        public CompanyListFormViewModel(
            IDialogService dialogService,
            IMapper mapper,
            SessionManager sessionManager,
            AddCompanyDialogViewModel addCompanyDialogViewModel)
        {
            _dialogService = dialogService;
            _addCompanyDialogViewModel = addCompanyDialogViewModel;
            _mapper = mapper;


            SessionViewModel = sessionManager.SessionViewModel;
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
            CompanyViewModel companyViewModel = _dialogService.OpenDialog(_addCompanyDialogViewModel);
            if (companyViewModel != null)
            {
                SessionViewModel.Companies.Add(companyViewModel);
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
            SessionViewModel.Companies.Remove(SessionViewModel.SelectedCompany);
        }
    }
}
