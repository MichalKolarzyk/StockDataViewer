using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SessionService
{
    public class Session 
    {
        public List<Company> Companies { get; set; } = new List<Company>();
    }
}
