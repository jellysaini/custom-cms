using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class HelpMe : System.Web.UI.Page
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
            Modikhana.BAL.OurHelp HelpObj = new Modikhana.BAL.OurHelp();
            GridHelp.DataSource = HelpObj.SelectAllHelp();
            GridHelp.DataBind();

        }

        protected void GridHelp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.OurHelp HelpObj = new Modikhana.BAL.OurHelp();
            if (HelpObj.DeleteHelp(Convert.ToInt32(GridHelp.DataKeys[e.RowIndex].Value)) == true)
            {
                BindGrid();
                success.Style.Add("display", "");
            }
            else
            {
                fail.Style.Add("display", "");
            }
        }

        protected void GridHelp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridHelp.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridHelp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("MessageReply.aspx?id=" + GridHelp.DataKeys[e.RowIndex].Value + "&page=help");
        }
    }
}