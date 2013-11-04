using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemberShipSystem
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/CreateProduct.aspx");
        }

        protected void btnShopFront_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/CreateOrder.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/Register.aspx");
        }

        protected void btnFinaliseOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/SubmitOrder.aspx");
        }
    }
}