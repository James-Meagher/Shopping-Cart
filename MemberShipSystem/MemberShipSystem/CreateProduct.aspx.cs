using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemberShipSystem
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PreviousPage"] = Page.Request.UrlReferrer.ToString();
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            MembershipSystemContext dbContext = new MembershipSystemContext(); 
            Product d = new Product { Name = txtName.Text, Details = txtDetails.Text, Price = decimal.Parse(txtPrice.Text) };
            dbContext.Products.Add(d);
            dbContext.SaveChanges();

            ClearPageTextboxes();

        }

        private void ClearPageTextboxes()
        {
            foreach (Control c in Page.Controls)
            {
                foreach (Control childc in c.Controls)
                {
                    if (childc is TextBox)
                    {
                        ((TextBox)childc).Text = string.Empty;
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect((String)ViewState["PreviousPage"]);
        }


    }
}