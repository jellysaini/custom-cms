using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class PayPalDonationDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PayPalDonationId"] != null)
                {
                    GetPayPalDonationData(Convert.ToInt32(Request.QueryString["PayPalDonationId"]));
                }
            }
        }
        private void GetPayPalDonationData(Int32 PayPalDonationId)
        {
            Modikhana.DAL.SelectPayPalReceiptByIDResult paypalData = new Modikhana.DAL.SelectPayPalReceiptByIDResult();
            Modikhana.BAL.PayPalReceipt PayPalReceiptObj = new Modikhana.BAL.PayPalReceipt();
            paypalData = PayPalReceiptObj.SelectPayPalReceiptById(PayPalDonationId);
            lblAmount.Text ="$"+ paypalData.Ammount;
            lblDonationDate.Text = paypalData.DonationDate.ToString();
            lblDonationType.Text = paypalData.DonationType;
            lblPayPalFirstName.Text = paypalData.FirstName;
            lblPayPalLastName.Text = paypalData.LastName;
            lblName.Text = paypalData.Name;
            lblPayPalEmail.Text = paypalData.PEmail;
            lblPurpose.Text = paypalData.Purpose;
            lblPalPalTransactionId.Text = paypalData.TransactionID;
            
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayPalDonation.aspx");
        }
    }
}