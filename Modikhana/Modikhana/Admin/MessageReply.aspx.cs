using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class MessageReply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["page"] != null)
            {
                if (!IsPostBack)
                {
                    GetData(Convert.ToInt32(Request.QueryString["id"]), Convert.ToString(Request.QueryString["page"]));
                }
            }
        }

        private void GetData(Int32 ID, String Type)
        {
            if (Type == "contact")
            {
                Modikhana.DAL.tblContactUs contactUsData = new Modikhana.DAL.tblContactUs();
                Modikhana.BAL.ContactUs ContactUsObj = new Modikhana.BAL.ContactUs();
                contactUsData = ContactUsObj.SelectContactUsById(ID);
                lblUserName.Text = contactUsData.UserName;
                lblUserEmail.Text = contactUsData.UserEmail;
                lblMessage.Text = contactUsData.ContactUsMessage;
            }
            else if (Type == "feedback")
            {
                Modikhana.DAL.tblFeedback feedbackData = new Modikhana.DAL.tblFeedback();
                Modikhana.BAL.Feedback FeedbackObj = new Modikhana.BAL.Feedback();
                feedbackData = FeedbackObj.SelectFeedbackById(ID);
                lblUserName.Text = feedbackData.UserName;
                lblUserEmail.Text = feedbackData.UserEmail;
                lblMessage.Text = feedbackData.FeedbackMessage;
            }
            else
            {
                Modikhana.DAL.SelectOurHelpByIdResult helpData = new Modikhana.DAL.SelectOurHelpByIdResult();
                Modikhana.BAL.OurHelp HelpkObj = new Modikhana.BAL.OurHelp();
                helpData = HelpkObj.SelectHelpById(ID);
                lblUserName.Text = helpData.FirstName;
                lblUserEmail.Text = helpData.EmailAddress;
                lblMessage.Text = helpData.HelpDEscription;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ckMessage.Text == "")
            {
                fail.Style.Add("display", "inline");
                success.Style.Add("display", "none");
            }
            else
            {
                Modikhana.DAL.tblEmailSetting emailData = new Modikhana.DAL.tblEmailSetting();
                Modikhana.BAL.EmailSetting emailObj = new Modikhana.BAL.EmailSetting();
                emailData = emailObj.SelectEmailSettingById(1);


                Modikhana.Commom.SendMail sendMail = new Modikhana.Commom.SendMail();


                Boolean retval = sendMail.SendEmailMethod(ckMessage.Text, "Modikhana Charitable Trust", lblUserEmail.Text, "", emailData.OutgoingMailServer.ToString(), emailData.UserName.ToString(), emailData.EmailPassword.ToString(), emailData.UserName.ToString(), Convert.ToBoolean(emailData.IsSSLEnabled), Convert.ToInt32(emailData.OutgoingPort), false);
                if (retval == true)
                {
                    success.Style.Add("display", "inline");
                    fail.Style.Add("display", "none");
                }
                else
                {
                    fail.Style.Add("display", "inline");
                    success.Style.Add("display", "none");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ckMessage.Text = "";
        }
    }
}