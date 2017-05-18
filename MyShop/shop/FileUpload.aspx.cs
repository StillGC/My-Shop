using MyShop.Model.Entities;
using MyShop.Model.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop.shop
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    string sFileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (sFileExtension.ToLower() != ".csv")
                    {
                        ((Site)this.Page.Master).ShowAlert("warning", "The file to upload does not match the format (.csv)");
                    }
                    else
                    {
                        string path = Server.MapPath(string.Format("~/upload/{0}.csv", Guid.NewGuid()));
                        FileUpload1.SaveAs(path);

                        string readText = File.ReadAllText(path);
                        string st = readText.Replace("\n", "°");
                        string[] csvs = st.Split('°');
                        for (int i = 0; i < csvs.Count() - 1; i++)
                        {
                            string[] vFileString = csvs[i].Split(';');

                            Product objProduct = new Product();
                            objProduct.Title = vFileString[0];
                            objProduct.Description = vFileString[1];
                            objProduct.Url = vFileString[2];
                            objProduct.Price = Convert.ToDecimal(vFileString[3]);
                            objProduct.Stars = Convert.ToInt32(vFileString[4]);

                            RepositoryFactory.GetProductRepository().Add(objProduct);
                        }

                        ((Site)this.Page.Master).ShowAlert("success", "File uploaded successfully");
                    }
                }
                else
                {
                    ((Site)this.Page.Master).ShowAlert("warning", "You must select a file");
                }
            }
            catch (Exception ex)
            {
                ((Site)this.Page.Master).ShowAlert("danger", "Error in File uploaded : " + ex.Message);
            }
        }
    }
}