using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.Utilities
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IDialogService>().To<DialogService>();
            //Bind<IDataService>().To<DataService>();
        }
    }
}
