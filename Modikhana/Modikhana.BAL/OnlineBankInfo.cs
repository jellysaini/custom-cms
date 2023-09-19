using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class OnlineBankInfo
    {
        public Int32 InsertOnlineBankInfo(tblOnlineBankInfo OnlineBankInfoData)
        {
            int retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will save new onlinebankinfo in the database

                tblOnlineBankInfo _onlinebankinfo = new tblOnlineBankInfo
                {
                    AccountHolder = OnlineBankInfoData.AccountHolder,
                    AccountNo = OnlineBankInfoData.AccountNo,
                    AccountType = OnlineBankInfoData.AccountType,
                    BankName = OnlineBankInfoData.BankName,
                    Branch = OnlineBankInfoData.Branch,
                    IFSCCode = OnlineBankInfoData.IFSCCode,
                    Status = OnlineBankInfoData.Status
                };

                db.tblOnlineBankInfos.InsertOnSubmit(_onlinebankinfo);
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

        public List<tblOnlineBankInfo> SelectAllOnlineBankInfo()
        {
            List<tblOnlineBankInfo> OnlineBankInfo = new List<tblOnlineBankInfo>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all onlinebankinfo list

                OnlineBankInfo = (from p in db.tblOnlineBankInfos
                                  orderby p.ID descending
                                  select p).ToList<tblOnlineBankInfo>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return OnlineBankInfo;
        }

        public List<tblOnlineBankInfo> SelectAllOnlineBankInfoByTrueStatus()
        {
            List<tblOnlineBankInfo> OnlineBankInfo = new List<tblOnlineBankInfo>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code return the all onlinebankinfo list

                OnlineBankInfo = (from p in db.tblOnlineBankInfos
                                  where p.Status == true
                                  orderby p.ID descending
                                  select p).ToList<tblOnlineBankInfo>();

                #endregion
            }
            catch (Exception)
            {
                db.Dispose();

            }
            return OnlineBankInfo;
        }

        public Boolean DeleteOnlineBankInfo(Int32 OnlineBankInfoId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the single OnlineBankInfo from the database

                var query = (from p in db.tblOnlineBankInfos
                             where p.ID == OnlineBankInfoId
                             select p).Single();

                db.tblOnlineBankInfos.DeleteOnSubmit(query);
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

        public tblOnlineBankInfo SelectOnlineBankInfoById(Int32 OnlineBankInfoId)
        {
            tblOnlineBankInfo OnlineBankInfo = new tblOnlineBankInfo();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database
                OnlineBankInfo = (from p in db.tblOnlineBankInfos
                                  where p.ID == OnlineBankInfoId
                                  select p).Single();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return OnlineBankInfo;
        }

        public Boolean UpdateOnlineBankInfo(tblOnlineBankInfo OnlineBankInfoData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will update the online bank info data according to its id

                tblOnlineBankInfo OnlineBankInfo = (from p in db.tblOnlineBankInfos
                                                    where p.ID == OnlineBankInfoData.ID
                                                    select p).Single();

                OnlineBankInfo.AccountHolder = OnlineBankInfoData.AccountHolder;
                OnlineBankInfo.AccountNo = OnlineBankInfoData.AccountNo;
                OnlineBankInfo.AccountType = OnlineBankInfoData.AccountType;
                OnlineBankInfo.BankName = OnlineBankInfoData.BankName;
                OnlineBankInfo.Branch = OnlineBankInfoData.Branch;
                OnlineBankInfo.IFSCCode = OnlineBankInfoData.IFSCCode;
                OnlineBankInfo.Status = OnlineBankInfoData.Status;
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
