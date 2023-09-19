using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Modikhana
{
    public partial class MyPost : System.Web.UI.Page
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
            MyPostGridView.DataSource = DiscussionTopicObj.SelectAllDiscussionTopicByCreatedId(Convert.ToInt32(Session["UserId"]));
            MyPostGridView.DataBind();
        }

        protected void MyPostGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MyPostGridView.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void MyPostGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
            if (DiscussionTopicObj.DeleteDiscussionTopic(Convert.ToInt32(MyPostGridView.DataKeys[e.RowIndex].Value)) == true)
            {
                BindGrid();
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Post is not deleted";
            }
        }

        protected void MyPostGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("NewPost.aspx?PostId=" + MyPostGridView.DataKeys[e.RowIndex].Value);
        }
    }
}