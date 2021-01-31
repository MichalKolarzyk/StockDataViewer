using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.Dialogs
{
    public class DialogService : IDialogService
    {
        private IDialogWindow _window;
        public T OpenDialog<T>(DialogViewModelBase<T> viewModel)
        {
            _window = new DialogWindow();
            _window.DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            _window.ShowDialog();
            return viewModel.DialogResult;
        }
    }
}
