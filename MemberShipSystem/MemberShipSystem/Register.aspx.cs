using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemberShipSystem
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PreviousPage"] = Page.Request.UrlReferrer.ToString();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            UserManager s = new UserManager();
            List<string> errors = s.CreateUser(txtUser.Text, txtPassword.Text, txtEmail.Text, txtQuestion.Text, txtAnswer.Text, "", int.Parse(DropDownList1.SelectedValue));

            lblRegErrors.Text = "<ul>";
            foreach (string error in errors)
                lblRegErrors.Text += string.Format("<li>{0}</li>", error);
            lblRegErrors.Text += "</ul>";



            if (!IsPostBack)
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
}