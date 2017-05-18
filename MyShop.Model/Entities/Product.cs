using System;

namespace MyShop.Model.Entities
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public int Stars { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
