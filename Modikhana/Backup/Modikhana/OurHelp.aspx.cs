using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Modikhana
{
    public partial class OurHelp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Modikhana.BAL.OurHelp OurHelpObj = new Modikhana.BAL.OurHelp();
            Modikhana.DAL.tblHelp HelpData = new Modikhana.DAL.tblHelp();
            HelpData.HelpDEscription = txtOurHelp.Text;
            HelpData.HelpPostDate = DateTime.Now;
            HelpData.UserId = Convert.ToInt32(Session["UserId"]);
            if (OurHelpObj.InsertOurHelp(HelpData) == true)
            {
                erroMsg.ForeColor = Color.Green;
                txtOurHelp.Text = "";
                erroMsg.Text = "One of our member will contact us soon.";
            }
            else
            {
                erroMsg.ForeColor = Color.Red;
                erroMsg.Text = "Your request is not sent successfully.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtOurHelp.Text = "";
        }
    }
}