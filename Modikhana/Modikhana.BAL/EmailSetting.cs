using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class EmailSetting
    {
        public tblEmailSetting SelectEmailSettingById(Int32 Id)
        {
            tblEmailSetting EmailSetting = new tblEmailSetting();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {

                #region This is code is EmailSetting to select the data of a single EmailSetting. It return the object of the tblEmailSetting which hold the all information of the tblEmailSetting

                EmailSetting = (from p in db.tblEmailSettings
                         where p.ID == Id
                         select p).Single();
                db.Dispose();

                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return EmailSetting;
        }

        public Boolean UpdateEmailSetting(tblEmailSetting emailSettingData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This method is Update the EmailSetting information of the EmailSetting according to EmailSetting id

                tblEmailSetting EmailSetting = (from p in db.tblEmailSettings
                                                where p.ID == emailSettingData.ID
                                 select p).Single();
                EmailSetting.IncomingMailServer = emailSettingData.IncomingMailServer;
                EmailSetting.IncomingPort = emailSettingData.IncomingPort;
                EmailSetting.IsSSLEnabled = emailSettingData.IsSSLEnabled;
                EmailSetting.OutgoingMailServer = emailSettingData.OutgoingMailServer;
                EmailSetting.OutgoingPort = emailSettingData.OutgoingPort;
                EmailSetting.UserName = emailSettingData.UserName;
                EmailSetting.EmailPassword = emailSettingData.EmailPassword;

                db.SubmitChanges();
                db.Dispose();
                retval = true;

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                retval = false;
            }
            return retval;
        }
    }
}
