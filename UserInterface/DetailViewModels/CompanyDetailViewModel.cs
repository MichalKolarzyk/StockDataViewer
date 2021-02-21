using AutoMapper;
using BaseModels;
using BaseModels.Extensions;
using OxyPlot;
using Services.ApplicationServices;
using Services.PlotService;
using Services.SessionService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Models;
using UserInterface.Utilities;

namespace UserInterface.DetailViewModels
{
    public class CompanyDetailViewModel : BaseViewModel
    {
        IPlotService _plotService;

        public SessionViewModel SessionViewModel { get; set; }
        public CompanyDetailViewModel(IPlotService plotService, SessionManager sessionManager)
        {
            _plotService = plotService;

            SessionViewModel = sessionManager.SessionViewModel;
        }

        //public PlotModel PlotModel
        //{
        //    get { return _plotService.GetPlotl<Price>().GetModel(Prices); }
        //}

    }
}
