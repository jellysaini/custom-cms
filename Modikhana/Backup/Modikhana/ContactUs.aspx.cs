using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Modikhana
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Modikhana.BAL.ContactUs ContactObj = new Modikhana.BAL.ContactUs();
            Modikhana.DAL.tblContactUs contactData = new Modikhana.DAL.tblContactUs();
            contactData.ContactUsMessage = txtMessage.Text;
            contactData.UserName = txtUserName.Text;
            contactData.UserEmail = txtEmailAddress.Text;
            contactData.ContactUsDate = DateTime.Now;
            if (ContactObj.InsertContactUs(contactData) == true)
            {
                msg.ForeColor = Color.Green;
                msg.Text = "Mail sent successfully";
                Clear();
            }
            else
            {
                msg.ForeColor = Color.Red;
                msg.Text = "Mail is not sent successfully";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtEmailAddress.Text = "";
            txtMessage.Text = "";
            txtUserName.Text = "";
        }
    }
}