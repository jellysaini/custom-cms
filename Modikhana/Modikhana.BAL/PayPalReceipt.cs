using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class PayPalReceipt
    {
        public Boolean InsertPayPalReceipt(String PTransactionID,String PEmail,String PFirstName,String PLastName,String PAmmount,DateTime DonationDate,String Name,String Purpose,String Ammount,String DonationType)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code is used to save the paypal donation into the database. Use SP
                db.SavePayPalReceipt(PTransactionID, PEmail, PFirstName, PLastName, PAmmount, DonationDate, Name, Purpose, Ammount, DonationType);
                db.Dispose();
                #endregion
                return true;
            }
            catch (Exception)
            {
                db.Dispose();
                return false;
            }
        }

        public List<SelectAllPayPalReceiptResult> SelectAllPayPalReceipt()
        {
            List<SelectAllPayPalReceiptResult> PayPalReceipt = new List<SelectAllPayPalReceiptResult>();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will get all the Discussion Topic from the database. Use SP

                PayPalReceipt = db.SelectAllPayPalReceipt().ToList<SelectAllPayPalReceiptResult>();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return PayPalReceipt;
        }


        public Boolean DeletePayPalReceipt(Int32 PayPalReceiptId)
        {
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will delete the single paypal receipt from the database

                var query = (from p in db.tblPayPalReceipts
                             where p.ID == PayPalReceiptId
                             select p).Single();

                db.tblPayPalReceipts.DeleteOnSubmit(query);
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

        public SelectPayPalReceiptByIDResult SelectPayPalReceiptById(Int32 PayPalReceiptId)
        {
            SelectPayPalReceiptByIDResult PayPalReceipt = new SelectPayPalReceiptByIDResult();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region This code will get all the Discussion Topic from the database. Use SP

                PayPalReceipt = db.SelectPayPalReceiptByID(PayPalReceiptId).Single();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }
            return PayPalReceipt;
        }
    }
}
