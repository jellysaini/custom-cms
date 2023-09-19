using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class DonationList : System.Web.UI.Page
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
            Modikhana.BAL.DonationDetail DonationDetailObj = new Modikhana.BAL.DonationDetail();
            GridDonation.DataSource = DonationDetailObj.SelectAllDonationDetail();
            GridDonation.DataBind();
        }

        protected void GridDonation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDonation.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridDonation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.DonationDetail DonationDetailObj = new Modikhana.BAL.DonationDetail();
            if (DonationDetailObj.DeleteDonationDetail(Convert.ToInt32(GridDonation.DataKeys[e.RowIndex].Value)) == true)
            {
                BindGrid();
                success.Style.Add("display", "");
                fail.Style.Add("display", "none");
            }
            else
            {
                fail.Style.Add("display", "");
                success.Style.Add("display", "none");
            }
        }

        protected void GridDonation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddDonation.aspx?DonationId=" + GridDonation.DataKeys[e.RowIndex].Value);
        }
    }
}