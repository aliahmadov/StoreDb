using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace StoreProducts_WPF.Domain.Views
{
    /// <summary>
    /// Interaction logic for ProductsDisplayUC.xaml
    /// </summary>
    public partial class ProductsDisplayUC : UserControl
    {
        public string ImagePath { get; set; }
        public ProductsDisplayUC(string imagePath)
        {
            InitializeComponent();
            ImagePath=imagePath;
        }

   

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ImagePath = "Images/fullHeart.png";
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ImagePath = "Images/heart.png";
        }
    }
}
