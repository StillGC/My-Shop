using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Model.Entities
{
    public class MyCart
    {
        public List<Product> ListProducts { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public MyCart()
        {
            ListProducts = new List<Product>();
            Quantity = 0;
            Total = 0;
        }
    }
}
