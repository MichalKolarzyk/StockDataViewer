using AutoMapper;
using Services.SessionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Models;

namespace UserInterface.Utilities
{
    public class SessionManager
    {

        public SessionManager(IMapper mapper, ISessionService sessionService)
        {
            SessionViewModel = mapper.Map<SessionModel>(sessionService.Session);
        }
        public SessionModel SessionViewModel { get; set; }
    }
}
