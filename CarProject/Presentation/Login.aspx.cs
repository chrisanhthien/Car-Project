using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarProject.Models;

namespace CarProject.Presentation
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User user = new User();
                user.Id = user.CheckUserValidity(txtUser.Text, txtPass.Text);
                if (user.Id == 0)
                {
                    StatusLbl.Text = "User Not valid";
                }
                else
                {
                    Application["userId"] = user.Id;
                    Response.Redirect("SaleWebPage.aspx");
                }
            }
           
           
        }
    }
}