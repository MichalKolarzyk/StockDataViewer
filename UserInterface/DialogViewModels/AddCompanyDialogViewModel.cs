using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.Dialogs;
using UserInterface.Utilities;

namespace UserInterface.DialogViewModels
{
    public class AddCompanyDialogViewModel : DialogViewModelBase<Company>
    {
        Company _company = new Company();
        public string Id
        {
            get { return _company.Id; }
            set 
            { 
                _company.Id = value;
                OnPropertyChanged(nameof(CanCreate));
            }
        }
        public string FullName
        {
            get { return _company.FullName; }
            set { _company.FullName = value; }
        }


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
            return true;
        }

        private void Create(object obj)
        {
            CloseDialogWithResult((IDialogWindow)obj, _company);
        }
    }
}
