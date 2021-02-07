using BaseModels;
using Ninject.Modules;
using Services.ApplicationServices;
using Services.DatabaseServices;
using Services.ShedulerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DetailViewModels;
using UserInterface.Dialogs;
using UserInterface.DialogViewModels;
using UserInterface.ViewModels;

namespace UserInterface.Utilities
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabaseService<Company>>().To<CompaniesDatabaseService>().InSingletonScope();
            Bind<IDataChecker<Company>>().To<YahooDataChecker>().InSingletonScope();
            Bind<ISorceService<Company>>().To<YahooSorceService>().InSingletonScope();
            Bind<IApplicationService>().To<ApplicationService>().InSingletonScope();
            Bind<IDialogService>().To<DialogService>().InSingletonScope();
            Bind<IScheduleService>().To<SchedulerService>().InSingletonScope();

            IEnumerable<Type> viewModels = Assembly.Load("UserInterface").GetTypes().Where(
                t => t.Namespace.Contains("ViewModels"));

            foreach(Type type in viewModels)
            {
                Bind(type).ToSelf().InSingletonScope();
            }
        }
    }
}
