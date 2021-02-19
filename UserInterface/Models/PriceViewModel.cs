using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Utilities;

namespace UserInterface.Models
{
    public class PriceViewModel : BaseViewModel
    {
        private float _value;
        public float Value 
        {
            get => _value;
            set => SetField(ref _value, value);
        }

        private DateTime _date = new DateTime();
        public DateTime Date 
        {
            get => _date;
            set => SetField(ref _date, value);
        }
    }
}
