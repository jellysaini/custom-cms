using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class PayPalDonation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            Modikhana.BAL.PayPalReceipt PayPalReceiptObj = new Modikhana.BAL.PayPalReceipt();
            GridPayPalDonation.DataSource = PayPalReceiptObj.SelectAllPayPalReceipt();
            GridPayPalDonation.DataBind();
        }

        protected void GridPayPalDonation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPayPalDonation.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridPayPalDonation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.PayPalReceipt PayPalReceiptObj = new Modikhana.BAL.PayPalReceipt();
            Modikhana.BAL.DonationDetail DonationDetailObj = new Modikhana.BAL.DonationDetail();
            if (PayPalReceiptObj.DeletePayPalReceipt(Convert.ToInt32(GridPayPalDonation.DataKeys[e.RowIndex].Values["ReceiptNo"])) == true && DonationDetailObj.DeleteDonationDetail(Convert.ToInt32(GridPayPalDonation.DataKeys[e.RowIndex].Values["ID"])) == true)
            {
                BindGrid();
            }
            else
            {
                fail.Style.Add("display", "");
            }
        }

        protected void GridPayPalDonation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("PayPalDonationDetail.aspx?PayPalDonationId=" + GridPayPalDonation.DataKeys[e.RowIndex].Values["ReceiptNo"]);
        }
    }
}