using MvvmWpfFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Utilities;

namespace UserInterface.Models
{
    public class SessionModel : BaseViewModel
    {
        private ObservableCollection<CompanyModel> _companies;
        public ObservableCollection<CompanyModel> Companies 
        {
            get => _companies;
            set => SetField(ref _companies, value);
        }

        private CompanyModel _selectedCompany;

        public CompanyModel SelectedCompany
        {
            get { return _selectedCompany; }
            set { 
                _selectedCompany = value;
                OnPropertyChanged();
            }
        }

    }
}
