using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StoreProducts_WPF.Domain.ViewModels
{
    public class ProductsMainViewModel:BaseViewModel
    {
        private BitmapImage imagePath;

        public BitmapImage ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }


        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        private string percentageDecrease;

        public string PercentageDecrease
        {
            get { return percentageDecrease; }
            set { percentageDecrease = value; OnPropertyChanged(); }
        }

        private string reducedPrice;

        public string ReducedPrice
        {
            get { return reducedPrice; }
            set { reducedPrice = value; OnPropertyChanged(); }
        }






    }
}
