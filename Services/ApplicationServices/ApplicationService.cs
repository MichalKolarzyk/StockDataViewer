using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ApplicationServices
{
    public class ApplicationService : IApplicationService
    {
        public ApplicationService()
        {
            ;
        }

        private object _selectedObject;
        public object SelectedObject 
        {
            get => _selectedObject;
            set
            {
                _selectedObject = value;
                OnSelectedObjectChange?.Invoke(this, null);
            }
        }

        public event EventHandler OnSelectedObjectChange;
    }
}
