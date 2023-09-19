using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;

namespace Modikhana.BAL
{
    public class DonationDetail
    {
        public Int32 InsertDonationDetail(tblDonationDetail DonationDetailData)
        {
            int retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new donation in the database

                tblDonationDetail _donation = new tblDonationDetail
                {
                    Ammount = DonationDetailData.Ammount,
                    DonationDate = DonationDetailData.DonationDate,
                    DonationType = DonationDetailData.DonationType,
                    Name = DonationDetailData.Name,
                    Purpose = DonationDetailData.Purpose,
                    ReceiptNo = DonationDetailData.ReceiptNo
                };

                db.tblDonationDetails.InsertOnSubmit(_donation);
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

        public List<tblDonationDetail> SelectAllDonationDetail()
        {
            List<tblDonationDetail> DonationDetail = new List<tblDonationDetail>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all donation list

                DonationDetail = (from p in db.tblDonationDetails
                                  where p.DonationType == "By Check" || p.DonationType == "Online Transfer"
                                  orderby p.ID descending
                                  select p).ToList<tblDonationDetail>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return DonationDetail;
        }

        public Boolean DeleteDonationDetail(Int32 DonationDetailId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the single donations from the database

                var query = (from p in db.tblDonationDetails
                             where p.ID == DonationDetailId
                             select p).Single();

                db.tblDonationDetails.DeleteOnSubmit(query);
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

        public tblDonationDetail SelectDonationDetailById(Int32 DonationDetailId)
        {
            tblDonationDetail DonationDetail = new tblDonationDetail();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database
                DonationDetail = (from p in db.tblDonationDetails
                                  where p.ID == DonationDetailId
                                  select p).Single();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return DonationDetail;
        }

        public Boolean UpdateDonationDetail(tblDonationDetail DonationDetailData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will update the donation data according to its id

                tblDonationDetail DonationDetail = (from p in db.tblDonationDetails
                                                    where p.ID == DonationDetailData.ID
                                                    select p).Single();

                DonationDetail.Ammount = DonationDetailData.Ammount;
               // DonationDetail.DonationDate = DonationDetailData.DonationDate;
                DonationDetail.DonationType = DonationDetailData.DonationType;
                DonationDetail.Name = DonationDetailData.Name;
                DonationDetail.Purpose = DonationDetailData.Purpose;
                DonationDetail.ReceiptNo = DonationDetailData.ReceiptNo;

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
