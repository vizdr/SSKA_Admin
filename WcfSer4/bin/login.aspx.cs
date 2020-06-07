using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WcfSer4
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
        }

        protected void btnLogIn_Click(object sender, EventArgs arg)
        {
            string login = txtUserName.Text;
            string password = txtPwd.Text;

            if (FormsAuthentication.Authenticate(login, password))
            {
                FormsAuthentication.RedirectFromLoginPage(login, true);
            }

            else
	        {
                lblMsg.Visible = true;
	        }
        }
    }
}