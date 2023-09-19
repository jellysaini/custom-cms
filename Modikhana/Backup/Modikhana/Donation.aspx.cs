using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana
{
    public partial class Donation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataList();
            }
            EnablePaypal();

        }

        private void EnablePaypal()
        {
            Modikhana.BAL.PaymentGatewayDetail PaymentGatewayDetailObj = new Modikhana.BAL.PaymentGatewayDetail();
            if (PaymentGatewayDetailObj.CheckPaymentGatewayStatus() == true)
            {
                paypal.Visible = true;
                paypaldetail.Visible = true;
            }
            else
            {
                paypal.Visible = false;
                paypaldetail.Visible = false;
            }


        }

        private void BindDataList()
        {
            Modikhana.BAL.OnlineBankInfo OnlineBankInfoObj = new Modikhana.BAL.OnlineBankInfo();
            DataListBankInfo.DataSource = OnlineBankInfoObj.SelectAllOnlineBankInfoByTrueStatus();
            DataListBankInfo.DataBind();
        }

        protected void btnPaypal_Click(object sender, ImageClickEventArgs e)
        {
            Session["Dname"] = txtName.Text;
            Session["DAmmount"] = txtAmmount.Text;

            //String tempString = txtPurpose.Text;
            //tempString = Server.HtmlEncode(tempString);
            //tempString = tempString.Replace(" ", "&nbsp;");
            //tempString = tempString.Replace("\r\n", "<br>");

            //Session["DPurpose"] = tempString;
            Session["DPurpose"] = txtPurpose.Text;
            Response.Redirect("ConfirmDonation.aspx");
        }
    }
}