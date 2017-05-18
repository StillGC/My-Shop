using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Model.Entities;
using System.Data;

namespace MyShop.Model.Repository
{
    public interface IProductRepository
    {
        List<Product> FindAll();
        DataTable GetAll();
        List<Product> FindByName(string sProductName);
        void Add(Product objProduct);
        void Update(Product objProduct);
        void Remove(Product objProduct);
    }
}
