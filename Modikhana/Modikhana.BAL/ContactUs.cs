using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class ContactUs
    {
        public Boolean InsertContactUs(tblContactUs ContactUsData)
        {
            Boolean retval = false;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code is used to save ContactUs data in th database

                tblContactUs _contactUs = new tblContactUs
                {
                    ContactUsDate = ContactUsData.ContactUsDate,
                    ContactUsMessage = ContactUsData.ContactUsMessage,
                    UserEmail = ContactUsData.UserEmail,
                    UserName = ContactUsData.UserName
                };
                db.tblContactUs.InsertOnSubmit(_contactUs);
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

        public List<tblContactUs> SelectAllContactUs()
        {
            List<tblContactUs> ContactUs = new List<tblContactUs>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region Get all ccontact us. It return the list of all contact us send by users.

                ContactUs = (from p in db.tblContactUs
                             orderby p.ID descending
                             select p).ToList<tblContactUs>();
                db.Dispose();

                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return ContactUs;
        }

        public tblContactUs SelectContactUsById(Int32 Id)
        {
            tblContactUs ContactUs = new tblContactUs();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region Get all ccontact us. It return the list of all contact us send by users.

                ContactUs = (from p in db.tblContactUs
                             where p.ID == Id
                             select p).SingleOrDefault();
                db.Dispose();

                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return ContactUs;
        }

        public Boolean DeleteContactUs(Int32 ContactId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to delete a single contact us. It return true if contact us deleted successfully and return false if contact us is not deleted successfully.

                var query = (from p in db.tblContactUs
                             where p.ID == ContactId
                             select p).Single();
                db.tblContactUs.DeleteOnSubmit(query);
                db.SubmitChanges();
                db.Dispose();
                return true;

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                return false;
            }
        }
    }
}
