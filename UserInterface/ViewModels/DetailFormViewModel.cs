using BaseModels;
using Services.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DetailViewModels;
using UserInterface.Models;
using UserInterface.Utilities;

namespace UserInterface.ViewModels
{
    public class DetailFormViewModel : BaseViewModel
    {
        CompanyDetailViewModel _companyDetailViewModel;
        SessionViewModel SessionViewModel { get; set; }
        public DetailFormViewModel(CompanyDetailViewModel companyDetailViewModel, SessionManager sessionManager)
        {
            _companyDetailViewModel = companyDetailViewModel;

            SessionViewModel = sessionManager.SessionViewModel;
            SessionViewModel.PropertyChanged += _applicationService_OnSelectedObjectChange;
        }
        
        private void _applicationService_OnSelectedObjectChange(object sender, EventArgs e)
        {
            SelectedViewModel = _companyDetailViewModel;
        }

        private BaseViewModel _selectecViewModel;
        public BaseViewModel SelectedViewModel 
        {
            get => _selectecViewModel;
            set => SetField(ref _selectecViewModel, value);
        }
    }
}
