using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modikhana.DAL;
namespace Modikhana.BAL
{
    public class PaymentGatewayDetail
    {
        public tblPaymentGatewayDetail SelectPaymentGatewayDetail()
        {
            tblPaymentGatewayDetail PaymentGatewayDetail = new tblPaymentGatewayDetail();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database
                PaymentGatewayDetail = (from p in db.tblPaymentGatewayDetails
                                        select p).SingleOrDefault();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return PaymentGatewayDetail;
        }

        public Boolean CheckPaymentGatewayStatus()
        {
            tblPaymentGatewayDetail PaymentGatewayDetail = new tblPaymentGatewayDetail();
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will select only single record from the database
                PaymentGatewayDetail = (from p in db.tblPaymentGatewayDetails
                                        select p).SingleOrDefault();
                db.Dispose();
                #endregion
            }
            catch (Exception)
            {
                db.Dispose();
            }

            return Convert.ToBoolean(PaymentGatewayDetail.Status);
        }

        public Boolean UpdatePaymentGatewayDetail(tblPaymentGatewayDetail PaymentGatewayDetailData)
        {
            Boolean retval;
            ModikhanaDataDataContext db = new ModikhanaDataDataContext();
            try
            {
                #region The below code will update the payment gateway detail data according to its id

                tblPaymentGatewayDetail PaymentGatewayDetail = (from p in db.tblPaymentGatewayDetails
                                                                where p.ID == PaymentGatewayDetailData.ID
                                                                select p).Single();

                PaymentGatewayDetail.BusineesEmail = PaymentGatewayDetailData.BusineesEmail;
                PaymentGatewayDetail.OrganizationName = PaymentGatewayDetailData.OrganizationName;
                PaymentGatewayDetail.PaymentGatewayName = PaymentGatewayDetailData.PaymentGatewayName;
                PaymentGatewayDetail.PDTToken = PaymentGatewayDetailData.PDTToken;
                PaymentGatewayDetail.Status = PaymentGatewayDetailData.Status;
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
