using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class PayPalInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPaymentGatewayData();
            }
        }

        private void GetPaymentGatewayData()
        {
            Modikhana.DAL.tblPaymentGatewayDetail paymentgatewayData = new Modikhana.DAL.tblPaymentGatewayDetail();
            Modikhana.BAL.PaymentGatewayDetail PaymentGatewayDetailObj = new Modikhana.BAL.PaymentGatewayDetail();
            paymentgatewayData = PaymentGatewayDetailObj.SelectPaymentGatewayDetail();
            txtBusineesEmail.Text = paymentgatewayData.BusineesEmail;
            txtOrganizationName.Text = paymentgatewayData.OrganizationName;
            txtPaymentGatewayName.Text = paymentgatewayData.PaymentGatewayName;
            txtPDTToken.Text = paymentgatewayData.PDTToken;
            ViewState["PID"] = paymentgatewayData.ID;
            PaymentGatewayStatus.Checked = Convert.ToBoolean(paymentgatewayData.Status);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblPaymentGatewayDetail paymentgatewayData = new Modikhana.DAL.tblPaymentGatewayDetail();
                paymentgatewayData.BusineesEmail = txtBusineesEmail.Text;
                paymentgatewayData.OrganizationName = txtOrganizationName.Text;
                paymentgatewayData.PaymentGatewayName = txtPaymentGatewayName.Text;
                paymentgatewayData.PDTToken = txtPDTToken.Text;
                paymentgatewayData.ID = Convert.ToInt32(ViewState["PID"]);
                paymentgatewayData.Status = PaymentGatewayStatus.Checked;
                Modikhana.BAL.PaymentGatewayDetail PaymentGatewayDetailObj = new Modikhana.BAL.PaymentGatewayDetail();
                if (PaymentGatewayDetailObj.UpdatePaymentGatewayDetail(paymentgatewayData) == true)
                {
                    success.Style.Add("display", "");
                    fail.Style.Add("display", "none");
                    ViewState["PID"] = null;
                }
                else
                {
                    fail.Style.Add("display", "");
                    success.Style.Add("display", "none");
                }

            }
            catch (Exception)
            {
                fail.Style.Add("display", "");
            }
        }
    }
}