using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProducts_WPF.Domain.Abstractions
{
    public interface IRepository<T>
    {
        T GetData(int id);
        void UpdateData(T data);
        void InsertData(T data);
        void DeleteData(T data);
         ObservableCollection<Product> GetAllData();
    }
}
