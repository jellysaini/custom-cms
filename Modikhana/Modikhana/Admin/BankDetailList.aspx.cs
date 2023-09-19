using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class BankDetailList : System.Web.UI.Page
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
            Modikhana.BAL.OnlineBankInfo OnlineBankInfoObj = new Modikhana.BAL.OnlineBankInfo();
            GridBanks.DataSource = OnlineBankInfoObj.SelectAllOnlineBankInfo();
            GridBanks.DataBind();
        }

        protected void GridBanks_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddBankDetail.aspx?BankinfoId=" + GridBanks.DataKeys[e.RowIndex].Value);
        }

        protected void GridBanks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.OnlineBankInfo OnlineBankInfoObj = new Modikhana.BAL.OnlineBankInfo();
            if (OnlineBankInfoObj.DeleteOnlineBankInfo(Convert.ToInt32(GridBanks.DataKeys[e.RowIndex].Value)) == true)
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

        protected void GridBanks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridBanks.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}