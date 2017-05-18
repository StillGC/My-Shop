using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop.shop
{
    public partial class MyUsers : System.Web.UI.Page
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
                this.list_role.DataSource = Roles.GetAllRoles();
                this.list_role.DataBind();
                this.gridview_listusers.DataSource = GetAllUsers();
                this.gridview_listusers.DataBind();
            }
            catch (Exception)
            {
            }
        }

        private List<MyShop.Model.Entities.User> GetAllUsers()
        {
            List<MyShop.Model.Entities.User> lstUsers = new List<MyShop.Model.Entities.User>();

            try
            {
                foreach (MembershipUser objItem in Membership.GetAllUsers())
                {
                    MyShop.Model.Entities.User objUser = new MyShop.Model.Entities.User();
                    objUser.UserName = objItem.UserName;
                    objUser.Email = objItem.Email;

                    lstUsers.Add(objUser);
                }
            }
            catch (Exception)
            {
            }

            return lstUsers;
        }

        private void CleanFields()
        {
            try
            {
                this.input_username.Value = "";
                this.input_password.Value = "";
                this.input_email.Value = "";
                this.list_role.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }

        protected void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                string sUserName = this.input_username.Value.Trim();
                string sPassword = this.input_password.Value.Trim();
                string sEmail = this.input_email.Value.Trim();
                string sRole = this.list_role.SelectedValue;

                if (Membership.FindUsersByName(sUserName).Count == 0)
                {
                    Membership.CreateUser(sUserName, sPassword, sEmail);
                    Roles.AddUserToRole(sUserName, sRole);
                }

                Refresh();
                CleanFields();
            }
            catch (Exception)
            {
            }
        }

        protected void gridview_listusers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Label UserName = gridview_listusers.Rows[e.RowIndex].FindControl("UserName") as Label;
                string sRole = Roles.GetRolesForUser(UserName.Text.Trim())[0];
                Roles.RemoveUserFromRole(UserName.Text.Trim(), sRole);
                Membership.DeleteUser(UserName.Text.Trim());

                Refresh();
            }
            catch (Exception)
            {
            }
        }
    }
}