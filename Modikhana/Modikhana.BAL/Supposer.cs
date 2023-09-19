using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class Supposer
    {
        public Int32 InsertSupposer(tblSupposer SupposerData)
        {
            int retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new supposer in the database

                tblSupposer _supposer = new tblSupposer
                {
                    SupposerName = SupposerData.SupposerName,
                    SupposerImagePath = SupposerData.SupposerImagePath,
                    SupposerStatus = SupposerData.SupposerStatus,
                };

                db.tblSupposers.InsertOnSubmit(_supposer);
                db.SubmitChanges();
                db.Dispose();
                retval = 1;

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
                retval = 0;
            }
            return retval;
        }

        public List<tblSupposer> SelectAllSupposer()
        {
            List<tblSupposer> Supposers = new List<tblSupposer>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all supposer list

                Supposers = (from p in db.tblSupposers
                             orderby p.ID descending
                             select p).ToList<tblSupposer>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return Supposers;
        }

        public List<tblSupposer> SelectAllSupposerByTrueStatus()
        {
            List<tblSupposer> Supposers = new List<tblSupposer>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all supposer list

                Supposers = (from p in db.tblSupposers
                             where p.SupposerStatus == true
                             orderby p.ID descending
                             select p).ToList<tblSupposer>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return Supposers;
        }

        public Boolean DeleteSupposer(Int32 SupposerId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the single supposer from the database

                var query = (from p in db.tblSupposers
                             where p.ID == SupposerId
                             select p).Single();

                db.tblSupposers.DeleteOnSubmit(query);
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

        public tblSupposer SelectSupposerById(Int32 SupposerId)
        {
            tblSupposer Supposer = new tblSupposer();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database
                Supposer = (from p in db.tblSupposers
                            where p.ID == SupposerId
                          select p).Single();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return Supposer;
        }

        public Boolean UpdateSupposer(tblSupposer SupposerData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will update the supposer data according to its id

                tblSupposer Supposer = (from p in db.tblSupposers
                                    where p.ID == SupposerData.ID
                                    select p).Single();

                Supposer.SupposerName = SupposerData.SupposerName;
                Supposer.SupposerImagePath = SupposerData.SupposerImagePath;
                Supposer.SupposerStatus = SupposerData.SupposerStatus;
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
