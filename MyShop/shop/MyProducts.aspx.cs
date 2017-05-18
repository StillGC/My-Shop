using MyShop.Model.Entities;
using MyShop.Model.Repository;
using MyShop.Model.Repository.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop.shop
{
    public partial class MyProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Refresh();
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

        private void Refresh()
        {
            try
            {
                this.gridview_listproducts.DataSource = RepositoryFactory.GetProductRepository().GetAll();
                this.gridview_listproducts.DataBind();
            }
            catch (Exception)
            {
            }
        }

        private void CleanFields()
        {
            try
            {
                this.input_title.Value = "";
                this.textarea_decription.Value = "";
                this.input_url.Value = "";
                this.input_prince.Value = "";
                this.input_start.Value = "";
            }
            catch (Exception)
            {
            }
        }

        protected void gridview_listproducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int IdProduct = int.Parse(gridview_listproducts.DataKeys[e.RowIndex].Values["id_Product"].ToString());
                Model.Entities.Product objProduct = new Model.Entities.Product();
                objProduct.IdProduct = IdProduct;

                RepositoryFactory.GetProductRepository().Remove(objProduct);
                Refresh();
            }
            catch (Exception)
            {
            }
        }

        protected void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Entities.Product objProduct = new Model.Entities.Product();
                objProduct.Title = this.input_title.Value;
                objProduct.Description = this.textarea_decription.Value;
                objProduct.Url = this.input_url.Value;
                objProduct.Price = decimal.Parse(this.input_prince.Value);
                objProduct.Stars = int.Parse(this.input_start.Value);

                RepositoryFactory.GetProductRepository().Add(objProduct);
                Refresh();
                CleanFields();
            }
            catch (Exception)
            {

            }
        }

        
    }
}