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
            kernel = new StandardKernel(new ServiceModule());
        }

        public MainViewModel MainViewModel
        {
            get { return kernel.Get<MainViewModel>(); }
        }

        public CompanyListViewModel CompanyListViewModel
        {
            get { return kernel.Get<CompanyListViewModel>(); }
        }

        public DetailViewModel DetailViewModel
        {
            get { return kernel.Get<DetailViewModel>(); }
        }

        public CompanyDetailViewModel CompanyDetailViewModel
        {
            get { return kernel.Get<CompanyDetailViewModel>(); }
        }

        public MenuBarViewModel MenuBarViewModel
        {
            get { return kernel.Get<MenuBarViewModel>(); }
        }
    }
}
