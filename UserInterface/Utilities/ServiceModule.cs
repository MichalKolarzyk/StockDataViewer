using BaseModels;
using Ninject.Modules;
using Services.ApplicationServices;
using Services.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Dialogs;

namespace UserInterface.Utilities
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabaseService<Company>>().To<CompaniesDatabaseService>();
            Bind<IApplicationService>().To<ApplicationService>().InSingletonScope();
            Bind<IDialogService>().To<DialogService>();
        }
    }
}
