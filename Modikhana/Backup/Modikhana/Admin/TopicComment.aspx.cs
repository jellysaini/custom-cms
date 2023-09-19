using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class TopicComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                BindGrid(Convert.ToInt32(drpTopics.SelectedValue));
            }
        }

        private void BindDropDown()
        {
            Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
            drpTopics.DataSource = DiscussionTopicObj.SelectAllDiscussionTopic();
            drpTopics.DataTextField = "TopicName";
            drpTopics.DataValueField = "ID";
            drpTopics.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(Convert.ToInt32(drpTopics.SelectedValue));
        }

        protected void GridTopicsComment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.TopicComments TopicCommentsObj = new Modikhana.BAL.TopicComments();
            if (TopicCommentsObj.DeleteTopicComment(Convert.ToInt32(GridTopicsComment.DataKeys[e.RowIndex].Value)) == true)
            {
                BindGrid(Convert.ToInt32(drpTopics.SelectedValue));
                success.Style.Add("display", "none");
            }
            else
            {
                fail.Style.Add("display", "");
            }
        }
        protected void btnComment_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblTopicComment topicCommentata = new Modikhana.DAL.tblTopicComment();
                topicCommentata.CreateedOn = DateTime.Now;
                topicCommentata.TopicComment = txtTopicComment.Text;
                topicCommentata.TopicId = Convert.ToInt32(drpTopics.SelectedValue);
                topicCommentata.UserId = Convert.ToInt32(Session["UserId"]);
                Modikhana.BAL.TopicComments TopicCommentsObj = new Modikhana.BAL.TopicComments();
                int Result = TopicCommentsObj.InsertTopicComment(topicCommentata);
                if (Result == 1)
                {
                    success.Style.Add("display", "");
                    GridTopicsComment.DataSource = TopicCommentsObj.SelectTopicCommentById(Convert.ToInt32(drpTopics.SelectedValue));
                    GridTopicsComment.DataBind();
                    txtTopicComment.Text = "";
                    Response.Redirect("TopicComment.aspx");
                }
                else
                {
                    fail.Style.Add("display", "");
                }
                TopicCommentsObj = null;
            }
            catch (Exception)
            {

                fail.Style.Add("display", "");
            }
        }

        private void BindGrid(Int32 CommentId)
        {
            Modikhana.BAL.TopicComments TopicCommentsObj = new Modikhana.BAL.TopicComments();
            GridTopicsComment.DataSource = TopicCommentsObj.SelectTopicCommentById(CommentId);
            GridTopicsComment.DataBind();
            TopicCommentsObj=null;
        }
    }
}