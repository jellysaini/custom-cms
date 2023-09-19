using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class PagesList : System.Web.UI.Page
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
            Modikhana.BAL.ContentManagement ContentPageObj = new Modikhana.BAL.ContentManagement();
            GridPages.DataSource = ContentPageObj.SelectAllPages();
            GridPages.DataBind();

        }

        protected void GridPages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPages.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridPages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.ContentManagement ContentPageObj = new Modikhana.BAL.ContentManagement();
            if (ContentPageObj.DeleteContentPage(Convert.ToInt32(GridPages.DataKeys[e.RowIndex].Value)) == true)
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

        protected void GridPages_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddPage.aspx?PageId=" + GridPages.DataKeys[e.RowIndex].Value);
        }
    }
}