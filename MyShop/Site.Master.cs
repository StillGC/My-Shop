using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FindProducts();

            MembershipUser objUser = Membership.GetUser();
            string sRole = Roles.GetRolesForUser(objUser.UserName)[0];
            ShowAlert(string.Empty, sRole);
        }

        private void FindProducts()
        {
            try
            {
                string sUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                if (sUrl.Contains("input_search"))
                {
                    string sValue = Request.QueryString.Count > 0 ? Request.QueryString[0] : "";
                    Response.Redirect(string.Format("~/shop/ListProducts.aspx?FindByName={0}", sValue));
                }
            }
            catch (Exception)
            {
            }
        }


        public void ShowAlert(string sType, string sMessage)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", string.Format("ShowAlert('{0}','{1}');", sType, sMessage), true);
        }
    }
}