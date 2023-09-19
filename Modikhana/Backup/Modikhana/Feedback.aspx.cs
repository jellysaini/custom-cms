using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Modikhana
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Modikhana.BAL.Feedback FeedbackObj = new Modikhana.BAL.Feedback();
            Modikhana.DAL.tblFeedback feedbackData = new Modikhana.DAL.tblFeedback();
            feedbackData.FeedbackMessage = txtMessage.Text;
            feedbackData.UserName = txtUserName.Text;
            feedbackData.UserEmail = txtEmailAddress.Text;
            feedbackData.FeedbackDate = DateTime.Now;
            if (FeedbackObj.InsertFeedback(feedbackData) == true)
            {
                msg.ForeColor = Color.Green;
                msg.Text = "Thanks for feedback";
                Clear();
            }
            else
            {
                msg.ForeColor = Color.Red;
                msg.Text = "Feedback is not sent";
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