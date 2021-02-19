using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Utilities;

namespace UserInterface.Models
{
    public class CompanyViewModel : BaseViewModel
    {
        private string _id = string.Empty;
        public string Id 
        {
            get => _id;
            set => SetField(ref _id, value, nameof(Id));
        }

        private string _fullName = string.Empty;
        public string FullName 
        {
            get => _fullName;
            set => SetField(ref _fullName, value, nameof(FullName));
        }

        private float _marketCup;
        public float MarketCup 
        {
            get => _marketCup;
            set => SetField(ref _marketCup, value);
        }

        private ObservableCollection<PriceViewModel> _prices = new ObservableCollection<PriceViewModel>();

        public ObservableCollection<PriceViewModel> Prices 
        {
            get => Prices;
            set
            {
                SetField(ref _prices, value);
                OnPropertyChanged(nameof(RegularMarketPrice));
            }
        }
        public float RegularMarketPrice
        {
            get
            {
                if (Prices.Count == 0) return default;
                return Prices[0].Value;
            }
        }

        public override string ToString()
        {
            return $"{FullName} {Id}";
        }
    }
}
