using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Utilities;

namespace UserInterface.Models
{
    public class SessionViewModel : BaseViewModel
    {
        private ObservableCollection<CompanyViewModel> _companies;
        public ObservableCollection<CompanyViewModel> Companies 
        {
            get => _companies;
            set => SetField(ref _companies, value);
        }
    }
}
