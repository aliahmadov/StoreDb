using StoreProducts_WPF.Domain.ViewModels;
using StoreProducts_WPF.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreProducts_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            var view = new MainMenuUC();
            var viewModel = new MainMenuViewModel();
            viewModel.ProductsWrapPanel = view.productPanel;
            view.DataContext=viewModel;
            App.MyGrid = MyGrid;
            App.MyGrid.Children.Add(view);
        }


    }
}
