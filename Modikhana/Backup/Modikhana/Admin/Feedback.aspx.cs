using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class Feedback : System.Web.UI.Page
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
            Modikhana.BAL.Feedback FeedbackObj = new Modikhana.BAL.Feedback();
            GridFeedback.DataSource = FeedbackObj.SelectAllFeedback();
            GridFeedback.DataBind();

        }

        protected void GridFeedback_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFeedback.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridFeedback_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.Feedback FeedbackObj = new Modikhana.BAL.Feedback();
            if (FeedbackObj.DeleteFeedback(Convert.ToInt32(GridFeedback.DataKeys[e.RowIndex].Value)) == true)
            {
                BindGrid();
                success.Style.Add("display", "");
            }
            else
            {
                fail.Style.Add("display", "");
            }
        }

        protected void GridFeedback_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("MessageReply.aspx?id=" + GridFeedback.DataKeys[e.RowIndex].Value + "&page=feedback");
        }
    }
}