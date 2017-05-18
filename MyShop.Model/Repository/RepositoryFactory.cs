using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Model.Repository
{
    public class RepositoryFactory
    {
        public static IProductRepository GetProductRepository()
        {
            return new MyShop.Model.Repository.Impl.ProductRepository();
        }
    }
}
