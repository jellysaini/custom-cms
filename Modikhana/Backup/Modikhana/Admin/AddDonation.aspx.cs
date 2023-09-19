using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class AddDonation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["DonationId"] != null)
            {
                if (!IsPostBack)
                {
                    GetDonationData(Convert.ToInt32(Request.QueryString["DonationId"]));
                }
            }
        }

        private void GetDonationData(Int32 DonationId)
        {
            Modikhana.DAL.tblDonationDetail donationData = new Modikhana.DAL.tblDonationDetail();
            Modikhana.BAL.DonationDetail DonationDetailObj = new Modikhana.BAL.DonationDetail();
            donationData = DonationDetailObj.SelectDonationDetailById(DonationId);
            txtAmmount.Text = donationData.Ammount;
            txtName.Text = donationData.Name;
            txtPurpose.Text = donationData.Purpose;
            txtReceiptNo.Text = donationData.ReceiptNo;
            drpDonationType.SelectedValue = donationData.DonationType;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblDonationDetail donationData = new Modikhana.DAL.tblDonationDetail();
                donationData.Ammount = txtAmmount.Text;
                donationData.DonationType = drpDonationType.SelectedValue;
                donationData.Name = txtName.Text;
                donationData.Purpose = txtPurpose.Text;
                donationData.ReceiptNo = txtReceiptNo.Text;

                Modikhana.BAL.DonationDetail DonationDetailObj = new Modikhana.BAL.DonationDetail();
                if (Request.QueryString["DonationId"] == null)
                {
                    donationData.DonationDate = DateTime.Now;
                    int Result = DonationDetailObj.InsertDonationDetail(donationData);
                    if (Result == 1)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("DonationList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    DonationDetailObj = null;
                }
                else
                {
                    donationData.ID = Convert.ToInt32(Request.QueryString["DonationId"]);
                    if (DonationDetailObj.UpdateDonationDetail(donationData) == true)
                    {
                        Response.Redirect("DonationList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    DonationDetailObj = null;
                }
            }
            catch (Exception)
            {
                fail.Style.Add("display", "");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DonationList.aspx");
        }
    }
}