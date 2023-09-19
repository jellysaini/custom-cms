using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class EmailSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmailSettingData();
            }
        }
        private void GetEmailSettingData()
        {
            Modikhana.DAL.tblEmailSetting emailSettingData = new Modikhana.DAL.tblEmailSetting();
            Modikhana.BAL.EmailSetting EmailSettingObj = new Modikhana.BAL.EmailSetting();
            emailSettingData = EmailSettingObj.SelectEmailSettingById(1);
            txtUserName.Text = emailSettingData.UserName;
            txtPassword.Text = emailSettingData.EmailPassword;
            txtIncomingEmailServer.Text = emailSettingData.IncomingMailServer;
            txtOutgoingEmailServer.Text = emailSettingData.OutgoingMailServer;
            txtIncomingPortNumber.Text = emailSettingData.IncomingPort.ToString();
            txtOutgoingPortNumber.Text = emailSettingData.OutgoingPort.ToString();
            chkIsSSLEnable.Checked = Convert.ToBoolean(emailSettingData.IsSSLEnabled);
            ViewState["Id"] = emailSettingData.ID;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Modikhana.DAL.tblEmailSetting emailSettingData = new Modikhana.DAL.tblEmailSetting();

            emailSettingData.UserName = txtUserName.Text;
            emailSettingData.EmailPassword = txtPassword.Text;
            emailSettingData.IncomingMailServer = txtIncomingEmailServer.Text;
            emailSettingData.IncomingPort = Convert.ToInt32(txtIncomingPortNumber.Text);
            emailSettingData.IsSSLEnabled = Convert.ToBoolean(chkIsSSLEnable.Checked);
            emailSettingData.OutgoingMailServer = txtOutgoingEmailServer.Text;
            emailSettingData.OutgoingPort = Convert.ToInt32(txtOutgoingPortNumber.Text);
            emailSettingData.ID = Convert.ToInt32(ViewState["Id"]);
            Modikhana.BAL.EmailSetting EmailSettingObj = new Modikhana.BAL.EmailSetting();
            if (EmailSettingObj.UpdateEmailSetting(emailSettingData) == true)
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