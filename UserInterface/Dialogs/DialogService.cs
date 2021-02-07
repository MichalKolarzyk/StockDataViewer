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
            _window.Height = viewModel.Height;
            _window.Width = viewModel.Width;
            _window.DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            bool? result = _window.ShowDialog();
            if(result == true)
            {
                return viewModel.DialogResult;
            }
            return default;
        }
    }
}
