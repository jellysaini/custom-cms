using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class Feedback
    {
        public Boolean InsertFeedback(tblFeedback FeedbackData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new feedback in database

                tblFeedback _feedback = new tblFeedback
                {
                    FeedbackDate = FeedbackData.FeedbackDate,
                    UserEmail = FeedbackData.UserEmail,
                    FeedbackMessage=FeedbackData.FeedbackMessage,
                    UserName=FeedbackData.UserName
                };
                db.tblFeedbacks.InsertOnSubmit(_feedback);
                db.SubmitChanges();
                db.Dispose();
                retval=true;

                #endregion
            }
            catch (Exception)
            {
                retval = false;
                db.Dispose();
            }
            return retval;
        }

        public List<tblFeedback> SelectAllFeedback()
        {
            List<tblFeedback> Feedback = new List<tblFeedback>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region Get all feeback. It return the list of all feedback send by users.

                Feedback = (from p in db.tblFeedbacks
                            orderby p.ID descending
                            select p).ToList<tblFeedback>();
                db.Dispose();

                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return Feedback;
        }

        public tblFeedback SelectFeedbackById(Int32 Id)
        {
            tblFeedback Feedback = new tblFeedback();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region Get all feeback. It return the list of all feedback send by users.

                Feedback = (from p in db.tblFeedbacks
                            where p.ID == Id
                            select p).SingleOrDefault();
                           
                            
                db.Dispose();

                #endregion

            }
            catch (Exception)
            {
                db.Dispose();
            }
            return Feedback;
        }

        public Boolean DeleteFeedback(Int32 FeedbackId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to delete a single feedback. It return true if feedback deleted successfully and return false if feedback is not deleted successfully.

                var query = (from p in db.tblFeedbacks
                             where p.ID == FeedbackId
                             select p).Single();
                db.tblFeedbacks.DeleteOnSubmit(query);
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
