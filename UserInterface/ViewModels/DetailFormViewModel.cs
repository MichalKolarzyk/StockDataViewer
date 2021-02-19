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
        IApplicationService _applicationService;
        CompanyDetailViewModel _companyDetailViewModel;
        public DetailFormViewModel(IApplicationService applicationService, 
            CompanyDetailViewModel companyDetailViewModel)
        {
            _applicationService = applicationService;
            _applicationService.OnSelectedObjectChange += _applicationService_OnSelectedObjectChange;

            _companyDetailViewModel = companyDetailViewModel;
        }
        
        public BaseViewModel SelectedViewModel { get; set; }

        private void _applicationService_OnSelectedObjectChange(object sender, EventArgs e)
        {
            if (_applicationService.SelectedObject is CompanyViewModel)
            {
                SelectedViewModel = _companyDetailViewModel;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
    }
}
