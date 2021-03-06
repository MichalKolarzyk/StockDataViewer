using MvvmWpfFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Utilities;

namespace UserInterface.Dialogs
{
    public abstract class DialogViewModelBase<T> : BaseViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public T DialogResult { get; set; }
        public double Height { get; set; } = 300;
        public double Width { get; set; } = 500;

        public void CloseDialogWithResult(IDialogWindow dialog, T result)
        {
            DialogResult = result;

            if (DialogResult != null)
                dialog.DialogResult = true;
        }
    }
}
