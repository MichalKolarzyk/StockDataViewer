using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DetailViewModels;
using UserInterface.ViewModels;

namespace UserInterface.Utilities
{
    public class ServiceLocator
    {
        private readonly IKernel kernel;

        public ServiceLocator()
        {
            kernel = new StandardKernel(new ServiceModule(), new AutoMapperModule());
        }

        public MainFormViewModel MainViewModel
        {
            get { return kernel.Get<MainFormViewModel>(); }
        }

        public CompanyListFormViewModel CompanyListViewModel
        {
            get { return kernel.Get<CompanyListFormViewModel>(); }
        }

        public DetailFormViewModel DetailViewModel
        {
            get { return kernel.Get<DetailFormViewModel>(); }
        }

        public CompanyDetailViewModel CompanyDetailViewModel
        {
            get { return kernel.Get<CompanyDetailViewModel>(); }
        }

        public MenuBarFormViewModel MenuBarViewModel
        {
            get { return kernel.Get<MenuBarFormViewModel>(); }
        }
    }
}
