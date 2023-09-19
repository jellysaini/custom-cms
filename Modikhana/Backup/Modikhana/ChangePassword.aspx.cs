using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Modikhana
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Modikhana.BAL.Login obj = new Modikhana.BAL.Login();
            if (obj.ChangePassword(Convert.ToString(Session["UserName"]), txtOldPassword.Text, txtNewPassword.Text) == true)
            {
                msg.ForeColor = Color.Green;
                msg.Text = "Your password has been changed successfully";
            }
            else
            {
                msg.ForeColor = Color.Red;
                msg.Text = "Sorry your password is not change.Please contact to Admmin";
            }
        }

       
    }
}