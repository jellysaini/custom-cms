using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {
            Modikhana.DAL.tblUser userData = new Modikhana.DAL.tblUser();
            Modikhana.BAL.Login obj = new Modikhana.BAL.Login();
            userData = obj.GetMailByLoginName(username_login.Text);


            Modikhana.DAL.tblEmailSetting emailData = new Modikhana.DAL.tblEmailSetting();
            Modikhana.BAL.EmailSetting emailObj = new Modikhana.BAL.EmailSetting();
            emailData = emailObj.SelectEmailSettingById(1);


           Modikhana.Commom.SendMail sendMail = new Modikhana.Commom.SendMail();

            String Content="<h1>Wel Come To Modi Khana Charitable Trust</h1><br/><br/><br>";
            Content += "Your New Password is " + userData.UserPassword+"<br/>";
            Content += "You can change your password afer login<br/><br/><br/>";
            Content += "<b>Best Regards</b><br/>";
            Content += "<i>Modi Khana Charitable Trust</i>";


            Boolean retval = sendMail.SendEmailMethod(Content, "Modi Khana Forget Password", userData.EmailAddress.ToString(), "", emailData.OutgoingMailServer.ToString(), emailData.UserName.ToString(), emailData.EmailPassword.ToString(), emailData.UserName.ToString(),Convert.ToBoolean(emailData.IsSSLEnabled),Convert.ToInt32(emailData.OutgoingPort), false);
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
}