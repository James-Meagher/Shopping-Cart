using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemberShipSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PreviousPage"] = Page.Request.UrlReferrer.ToString();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)ViewState["PreviousPage"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            UserManager s = new UserManager();
            if (s.Login(txtUserName.Text, txtPassword.Text) && (string)ViewState["PreviousPage"] != null)
            {
                Response.Redirect((string)ViewState["PreviousPage"]);
            }
            else if (s.Login(txtUserName.Text, txtPassword.Text) && (string)ViewState["PreviousPage"] == null)
            {
                Response.Redirect(@"/Index.aspx");
            }
            else
            {
                FailureText.Text = "User not found";
            }
        }
    }
}