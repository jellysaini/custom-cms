using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana
{
    public partial class Forums : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            if(User.Identity.IsAuthenticated==false)
            {
                btnNewPost.Visible = false;
                btnMyPost.Visible = false;
            }

        }

        private void BindGrid()
        {
            Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
            List<Modikhana.DAL.SelectAllDiscussionTopicResult> DiscussionTopicData = new List<Modikhana.DAL.SelectAllDiscussionTopicResult>();
            DiscussionTopicData = DiscussionTopicObj.SelectAllDiscussionTopic();
            GridViewForums.DataSource = DiscussionTopicData.Where(x => x.TopicStatus == true).ToList<Modikhana.DAL.SelectAllDiscussionTopicResult>();
            GridViewForums.DataBind();
        }

        protected void GridViewForums_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewForums.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnNewPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewPost.aspx");
        }

        protected void btnMyPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyPost.aspx");
        }
    }
}