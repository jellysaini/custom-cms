using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class OurWork
    {
        public Int32 InsertOurWork(tblOurWork OurWorkData)
        {
            int retval = 1;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new OurWork in the database

                tblOurWork _ourWork = new tblOurWork
                {
                    WorkDescription = OurWorkData.WorkDescription,
                    WorkImagePath = OurWorkData.WorkImagePath,
                    WorkName = OurWorkData.WorkName,
                    WorkOrder = OurWorkData.WorkOrder,
                    WorkStatus = OurWorkData.WorkStatus
                };

                db.tblOurWorks.InsertOnSubmit(_ourWork);
                db.SubmitChanges();
                db.Dispose();
                retval = 1;

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                retval = 2;
            }
            return retval;
        }

        public List<tblOurWork> SelectAllOurWork()
        {
            List<tblOurWork> OurWork = new List<tblOurWork>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all tblOurWork list

                OurWork = (from p in db.tblOurWorks
                           orderby p.ID descending
                           select p).ToList<tblOurWork>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return OurWork;
        }

        public List<tblOurWork> SelectNOurWork(Int32 NoOfRecord)
        {
            List<tblOurWork> OurWork = new List<tblOurWork>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all tblOurWork list

                OurWork = (from p in db.tblOurWorks
                           orderby p.ID descending
                           select p).Take(NoOfRecord).ToList<tblOurWork>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return OurWork;
        }

        public List<tblOurWork> SelectAllOurWorkByTrueStatus()
        {
            List<tblOurWork> OurWork = new List<tblOurWork>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all tblOurWork list

                OurWork = (from p in db.tblOurWorks
                           where p.WorkStatus == true
                           orderby p.ID descending
                           select p).ToList<tblOurWork>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return OurWork;
        }

        public Boolean DeleteOurWork(Int32 OurWorkId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the single our work from the database

                var query = (from p in db.tblOurWorks
                             where p.ID == OurWorkId
                             select p).Single();

                db.tblOurWorks.DeleteOnSubmit(query);
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

        public tblOurWork SelectOurWorkById(Int32 OurWorkId)
        {
            tblOurWork OurWork = new tblOurWork();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database
                OurWork = (from p in db.tblOurWorks
                           where p.ID == OurWorkId
                          select p).Single();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return OurWork;
        }

        public Boolean UpdateOurWork(tblOurWork OurWorkData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will update the our work data according to its id

                tblOurWork OurWork = (from p in db.tblOurWorks
                                    where p.ID == OurWorkData.ID
                                    select p).Single();

                OurWork.WorkDescription = OurWorkData.WorkDescription;
                OurWork.WorkImagePath = OurWorkData.WorkImagePath;
                OurWork.WorkName = OurWorkData.WorkName;
                OurWork.WorkOrder = OurWorkData.WorkOrder;
                OurWork.WorkStatus = OurWorkData.WorkStatus;
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
