using MyShop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Session.Clear();
                this.Session.Abandon();
                FormsAuthentication.SignOut();
            }

          
        }

        protected void Login_LoggedIn(object sender, EventArgs e)
        {
            MyCart objMyCart = new MyCart();
            this.Session.Add("MyCart", objMyCart);

            Response.Redirect("~/Shop/ListProducts.aspx");
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
            ShowAlert("danger", "Username or Password incorrect");
        }

        private void ShowAlert(string sType, string sMessage)
        {
            ClientScript.RegisterStartupScript(GetType(), "ShowMessage", string.Format("ShowAlert('{0}','{1}');", sType, sMessage), true);
        }
    }
}