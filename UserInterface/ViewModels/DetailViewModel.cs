using BaseModels;
using Services.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Utilities;

namespace UserInterface.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private Company _company = new Company();

        IApplicationService _applicationService;
        public DetailViewModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;
            _applicationService.OnSelectedObjectChange += _applicationService_OnSelectedObjectChange;
        }

        private void _applicationService_OnSelectedObjectChange(object sender, EventArgs e)
        {
            if(_applicationService.SelectedObject is Company company)
            {
                _company = company;
                OnPropertyChanged(nameof(Id));
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Id
        {
            get { return _company.Id; }
            set 
            { 
                _company.Id = value;
            }
        }

        public string FullName
        {
            get { return _company.FullName; }
            set { _company.FullName = value; }
        }

    }
}
