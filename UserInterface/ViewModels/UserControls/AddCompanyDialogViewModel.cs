using AutoMapper;
using BaseModels;
using MvvmWpfFramework.Commands;
using Services.DataService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.Dialogs;
using UserInterface.Models;
using UserInterface.Utilities;

namespace UserInterface.DialogViewModels
{
    public class AddCompanyDialogViewModel : DialogViewModelBase<CompanyModel>
    {


        IMapper _mapper;
        ISourceService _sourceService;
        public AddCompanyDialogViewModel(ISourceService sourceService, IMapper mapper)
        {
            _sourceService = sourceService;
            _mapper = mapper;

        }

        private CompanyModel _companyViewModel = new CompanyModel();
        public CompanyModel CompanyViewModel
        {
            get => _companyViewModel;
            set => SetField(ref _companyViewModel, value);
        }

        public string Id
        {
            get { return CompanyViewModel.Id; }
            set
            {
                CompanyViewModel.Id = value;
                UpdateCompany(CompanyViewModel.Id);
            }
        }

        private void UpdateCompany(string id)
        {
            Company result = _sourceService.Get<Company>(id);
            if(result != null)
            {
                CompanyViewModel = _mapper.Map<CompanyModel>(result);
            }
            else
            {
                CompanyViewModel.FullName = "";
                CompanyViewModel.Prices = new ObservableCollection<PriceModel>();
                CompanyViewModel.MarketCup = default;
            }
            ((RelayCommand)CreateCommand).NotifyCanExecuteChange();
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
            if (string.IsNullOrEmpty(CompanyViewModel.FullName)) return false;
            return true;
        }

        private void Create(object obj)
        {
            CloseDialogWithResult((IDialogWindow)obj, CompanyViewModel);
        }
        #endregion
    }
}
