using BaseModels;
using Ninject.Modules;
using Services.DataService;
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
            Bind<IDialogService>().To<DialogService>().InSingletonScope();

            IEnumerable<Type> serviceAssemblyTypes = Assembly.Load("Services").GetTypes();

            IEnumerable<Type> interfaceTypes = serviceAssemblyTypes.Where(x => x.Name.Contains("Service") && x.Name.StartsWith("I"));
            foreach(Type intefaceType in interfaceTypes)
            {
                string serviceClassName = intefaceType.Name.Substring(1, intefaceType.Name.Length - 1);
                Bind(intefaceType).To(serviceAssemblyTypes.FirstOrDefault(obj => obj.Name == serviceClassName)).InSingletonScope();
            }

            IEnumerable<Type> viewModels = Assembly.Load("UserInterface").GetTypes().Where(
                t => t.Namespace.Contains("ViewModels"));

            foreach(Type type in viewModels)
            {
                Bind(type).ToSelf().InSingletonScope();
            }
        }
    }
}
