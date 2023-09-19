using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Modikhana.BAL.Login obj = new Modikhana.BAL.Login();
            if (obj.ChangePassword(Convert.ToString(Session["UserName"]), txtOldPassword.Text, txtNewPassword.Text) == true)
            {
                success.Style.Add("display", "");
            }
            else
            {
                fail.Style.Add("display", "");
            }
        }
    }
}