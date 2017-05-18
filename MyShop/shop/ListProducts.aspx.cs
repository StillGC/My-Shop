using MyShop.Model.Entities;
using MyShop.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace MyShop.shop
{
    public partial class ListProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Product> ListProducts = new List<Product>();
                if (Request.QueryString["FindByName"] != null)
                {
                    ListProducts = RepositoryFactory.GetProductRepository().FindByName(Request.QueryString["FindByName"].ToString());
                }
                else
                {
                    ListProducts = RepositoryFactory.GetProductRepository().FindAll();
                }

                this.repeater_listproducts.DataSource = ListProducts;
                this.repeater_listproducts.DataBind();
            }
        }

        public String GetStars(object stars)
        {
            int limite = Convert.ToInt32(stars);
            int maximo = 5;
            int resultado = maximo - limite;

            StringBuilder str = new StringBuilder();

            for (int i = 1; i <= limite; i++)
            {
                str.Append("<i class=\"fa fa-star\" aria-hidden=\"true\"></i>");
            }

            for (int i = 1; i <= resultado; i++)
            {
                str.Append("<i class=\"fa fa-star-o\" aria-hidden=\"true\"></i>");
            }

            return str.ToString();
        }

        protected void repeater_listproducts_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Save")
                {
                    string[] vParameter = e.CommandArgument.ToString().Split('|');

                    Product objProduct = new Product();
                    objProduct.IdProduct = int.Parse(vParameter[0]);
                    objProduct.Title = vParameter[1];
                    objProduct.Price = decimal.Parse(vParameter[2]);
                    objProduct.Url = vParameter[3];
                    objProduct.Quantity = 1;
                    objProduct.SubTotal = objProduct.Price;

                    MyCart objCart = this.Session["MyCart"] as MyCart;

                    bool bExistProduct = false;
                    decimal iTotalPrince = 0;
                    for (int i = 0; i < objCart.ListProducts.Count; i++)
                    {
                        if (objCart.ListProducts[i].IdProduct.Equals(objProduct.IdProduct))
                        {
                            objCart.ListProducts[i].Quantity = (objCart.ListProducts[i].Quantity + 1);
                            objCart.ListProducts[i].SubTotal = (objCart.ListProducts[i].Quantity * objCart.ListProducts[i].Price);
                            bExistProduct = true;
                        }

                        iTotalPrince = iTotalPrince + (objCart.ListProducts[i].Quantity * objCart.ListProducts[i].Price);
                    }

                    if (!bExistProduct)
                    {
                        objCart.ListProducts.Add(objProduct);

                        iTotalPrince = iTotalPrince + (objProduct.Quantity * objProduct.Price);
                    }

                    objCart.Total = iTotalPrince;
                    this.Session["MyCart"] = objCart;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}