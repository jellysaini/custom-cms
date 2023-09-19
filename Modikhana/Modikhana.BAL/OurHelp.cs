using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class OurHelp
    {
        public Boolean InsertOurHelp(tblHelp HelpData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new Help data in the database

                tblHelp _help = new tblHelp
                {
                    HelpDEscription=HelpData.HelpDEscription,
                    HelpPostDate=HelpData.HelpPostDate,
                    UserId=HelpData.UserId
                };
                db.tblHelps.InsertOnSubmit(_help);
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

        public List<SelectOurHelpResult> SelectAllHelp()
        {
            List<SelectOurHelpResult> OurHelp = new List<SelectOurHelpResult>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region Get all. It return the list of all feedback send by users.

                OurHelp = db.SelectOurHelp().ToList <SelectOurHelpResult>();
                db.Dispose();
               
                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return OurHelp;
        }

        public SelectOurHelpByIdResult SelectHelpById(Int32 Id)
        {
            SelectOurHelpByIdResult OurHelp = new SelectOurHelpByIdResult();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region Get all. It return the list of all feedback send by users.

                OurHelp = db.SelectOurHelpById(Id).SingleOrDefault();
                db.Dispose();

                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return OurHelp;
        }


        public Boolean DeleteHelp(Int32 HelpId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to delete a single help. It return true if help deleted successfully and return false if help is not deleted successfully.

                
                var query = (from p in db.tblHelps
                             where p.ID == HelpId
                             select p).Single();
                db.tblHelps.DeleteOnSubmit(query);
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
