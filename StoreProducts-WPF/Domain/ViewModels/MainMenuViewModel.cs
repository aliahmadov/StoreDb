using StoreProducts_WPF.Commands;
using StoreProducts_WPF.DataAccess;
using StoreProducts_WPF.Domain.Abstractions;
using StoreProducts_WPF.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace StoreProducts_WPF.Domain.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public WrapPanel ProductsWrapPanel { get; set; }

        private readonly IProductRepository _productRepository;
        public RelayCommand ShowCommand { get; set; }

        public string ImagePath { get; set; }

        private BitmapImage GetImageSource(string uri)
        {
            var imgUrl = new Uri(uri);
            var imageData = new WebClient().DownloadData(imgUrl);

            var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(imageData);
            bitmapImage.EndInit();

            return bitmapImage;

        }


        public void AddUcToPanel(ObservableCollection<Product> products)
        {

            for (int i = 0; i < 20; i++)
            {
                var uC = new ProductsDisplayUC(ImagePath);
                var viewModel = new ProductsMainViewModel();
                uC.DataContext = viewModel;

                var fullFilePath = "https://" + products[i].Image;
                viewModel.ImagePath = GetImageSource(fullFilePath);



                double price = Convert.ToDouble(products[i].Price);
                double reducedPrice = Convert.ToDouble(products[i].ReducedPrice);
                viewModel.PercentageDecrease = Convert.ToInt32(((((price - reducedPrice) / price) * 100))).ToString() + "%";

                viewModel.Price = "$" + products[i].Price.ToString() + ".00";
                if (products[i].ReducedPrice.Contains("."))
                    viewModel.ReducedPrice = "$" + products[i].ReducedPrice + "0";
                else
                    viewModel.ReducedPrice = "$" + products[i].ReducedPrice + ".00";
                viewModel.Description = products[i].Name;

                uC.Width = 300;
                uC.Height = 500;
                uC.Margin = new System.Windows.Thickness(10, 40, 10, 10);

                ProductsWrapPanel.Children.Add(uC);
            }

        }

        public async Task ShowData()
        {
            Thread thread = new Thread(() =>
            {
                Application.Current.Dispatcher.Invoke(async () =>
                {

                    var products = await Task.Run(() => _productRepository.GetAllData());

                    if (products != null)
                    {
                        AddUcToPanel(products);
                    }
                });

            });
            thread.Start();
        }

        public MainMenuViewModel()
        {
            _productRepository = new ProductRepository();
            ImagePath = "/Images/heart.png";
            Task.Run(() =>
            {
                ShowCommand = new RelayCommand(async (a) =>
                {
                    await Task.Run(() => ShowData());

                });
            });
        }

    }
}
