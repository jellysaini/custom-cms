using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class EventList : System.Web.UI.Page
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
            Modikhana.BAL.Event EventObj = new Modikhana.BAL.Event();
            GridEvents.DataSource = EventObj.SelectAllEvent();
            GridEvents.DataBind();
        }

        protected void GridEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridEvents.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridEvent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.Event EventObj = new Modikhana.BAL.Event();
            if (EventObj.DeleteEvent(Convert.ToInt32(GridEvents.DataKeys[e.RowIndex].Value)) == true)
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

        protected void GridEvent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddEvent.aspx?EventId=" + GridEvents.DataKeys[e.RowIndex].Value);
        }
    }
}