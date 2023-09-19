using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Modikhana
{
    public partial class Public : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                lnkLogout.Visible = false;
                sp.Visible = false;

                lnkChangePwd.Visible = false;
                sp1.Visible = false;

                lnkProfile.Visible = false;
                sp2.Visible = false;

            }
            else
            {
                lnkLogout.Visible = true;
                sp.Visible = true;

                lnkChangePwd.Visible = true;
                sp1.Visible = true;

                lnkProfile.Visible = true;
                sp2.Visible = true;
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }

        protected void lnkChangePwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}