using StoreProducts_WPF.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProducts_WPF.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDataClassesDataContext _dtx;

        public ProductRepository()
        {
            _dtx = new StoreDataClassesDataContext();
        }
        public void DeleteData(Product data)
        {

            _dtx.Products.DeleteOnSubmit(data);
            _dtx.SubmitChanges();
        }

        public  ObservableCollection<Product> GetAllData()
        {
             return new ObservableCollection<Product>(_dtx.Products.Take(20));
        }



        public Product GetData(int id)
        {
            return _dtx.Products.FirstOrDefault(d => d.Id == id);
        }

        public void InsertData(Product data)
        {
            
            _dtx.Products.InsertOnSubmit(data);

            _dtx.SubmitChanges();
        }


        public void UpdateData(Product data)
        {
            var product = _dtx.Products.FirstOrDefault(d => d.Id == data.Id);

            product.Id = data.Id;
            product.Url = data.Url;
            product.Price = data.Price;
            product.Name = data.Name;
            product.Image = data.Image;
            product.BadgeType=data.BadgeType;
            product.ProductType=data.ProductType;
            product.ColourWayId=data.ColourWayId;
            product.IsSale = data.IsSale;
            product.ReducedPrice = data.ReducedPrice;
            product.HasMultiplePrices = data.HasMultiplePrices;
            product.IsOutlet = data.IsOutlet;
            product.IsSellingFast = data.IsSellingFast;
            product.PageNumber = data.PageNumber;
            product.TileId = data.TileId;
            product.Colour = data.Colour;
            product.CategoryName = data.CategoryName;
            product.BaseUrl = data.BaseUrl;
            product.MainCategory = data.MainCategory;
            product.BrandName = data.BrandName;
            product.ProductRating = data.ProductRating;
            product.ProductCode = data.ProductCode;
            product.ProductDescription = data.ProductDescription;

            _dtx.SubmitChanges();
        }
    }
}
