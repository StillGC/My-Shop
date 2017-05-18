using MyShop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop.shop
{
    public partial class MyCartDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            try
            {
                MyCart objCart = this.Session["MyCart"] as MyCart;

                repeater_mycart.DataSource = objCart.ListProducts;
                repeater_mycart.DataBind();

                strong_total.InnerText = "Total $" + objCart.Total.ToString();
            }
            catch (Exception)
            {
            }
        }

        protected void repeater_mycart_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    MyCart objCart = this.Session["MyCart"] as MyCart;

                    Product objProduct = new Product();
                    objProduct.IdProduct = int.Parse(e.CommandArgument.ToString());

                    for (int i = 0; i < objCart.ListProducts.Count; i++)
                    {
                        if (objCart.ListProducts[i].IdProduct.Equals(objProduct.IdProduct))
                        {
                            objCart.Total = objCart.Total - objCart.ListProducts[i].SubTotal;
                            objCart.ListProducts.RemoveAt(i);
                            break;
                        }
                    }

                    Refresh();
                }
            }
            catch (Exception)
            {

            }
        }

        private string TemplateEmail(MyCart objMyCart)
        {
            StringBuilder sbTemplate = new StringBuilder();

            try
            {
                sbTemplate.Append("Thanks for choosing us");
                sbTemplate.Append("<br />");
                sbTemplate.Append("<b>Sale detail:</b>");
                sbTemplate.Append("<br />");
                sbTemplate.Append("<br />");
                sbTemplate.Append("<table>");
                sbTemplate.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", "Product", "Price", "Quantity", "SubTotal");
                foreach (Product item in objMyCart.ListProducts)
                {
                    sbTemplate.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", item.Title, item.Price, item.Quantity, item.SubTotal);
                }
                sbTemplate.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", string.Empty, string.Empty, string.Empty, objMyCart.Total.ToString());
                sbTemplate.Append("</table>");
            }
            catch (Exception)
            {
            }

            return sbTemplate.ToString();
        }

        protected void button_checkout_Click(object sender, EventArgs e)
        {
            try
            {
                MyCart objCart = this.Session["MyCart"] as MyCart;
                if (objCart.ListProducts.Count > 0)
                {
                    MembershipUser objUser = Membership.GetUser();

                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(objUser.Email));
                    email.From = new MailAddress("stillgonzales@gmail.com");
                    email.Subject = "Buy product in my shop ( " + DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss") + " ) ";
                    email.Body = TemplateEmail(objCart);
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.Normal;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("stillgonzales@gmail.com", "3177094218");

                    smtp.Send(email);
                    email.Dispose();

                    this.Session["MyCart"] = new MyCart();
                    Response.Redirect("MyProducts.aspx");

                    ((Site)this.Page.Master).ShowAlert("success", "Send email with detail of sale. Done");
                }
                else
                {
                    ((Site)this.Page.Master).ShowAlert("warnning", "You must at least add a product to the shopping cart");
                }
            }
            catch (Exception ex)
            {
                ((Site)this.Page.Master).ShowAlert("danger", "Error in send email: " + ex.Message);
            }
        }
    }
}