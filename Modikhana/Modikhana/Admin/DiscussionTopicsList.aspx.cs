using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class DiscussionTopicsList : System.Web.UI.Page
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
            Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
            GridDiscussionTopics.DataSource = DiscussionTopicObj.SelectAllDiscussionTopic();
            GridDiscussionTopics.DataBind();
        }

        protected void GridDiscussionTopics_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDiscussionTopics.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridDiscussionTopics_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
            if (DiscussionTopicObj.DeleteDiscussionTopic(Convert.ToInt32(GridDiscussionTopics.DataKeys[e.RowIndex].Value)) == true)
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

        protected void GridDiscussionTopics_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddDiscussionTopics.aspx?DiscussionTopicId=" + GridDiscussionTopics.DataKeys[e.RowIndex].Value);
        }
    }
}