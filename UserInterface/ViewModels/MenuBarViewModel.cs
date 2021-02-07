using Services.ShedulerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserInterface.Utilities;

namespace UserInterface.ViewModels
{
    public class MenuBarViewModel
    {
        IScheduleService _scheduleService;
        public MenuBarViewModel(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        private ICommand _settingsCommand;

        public ICommand SettingsCommand
        {
            get 
            {
                if (_settingsCommand == null) _settingsCommand = new RelayCommand(SettingsMethod);
                return _settingsCommand; 
            }
        }

        private void SettingsMethod(object obj)
        {
            _scheduleService.Start();
            _scheduleService.ScheduleJob(() => MessageBox.Show("Job hello"), "0 * * ? * *");
        }
    }
}
