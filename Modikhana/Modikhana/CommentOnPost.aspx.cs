using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Modikhana
{
    public partial class CommentOnPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["Post"] != null)
            {
                if (!IsPostBack)
                {
                    ViewState["PostID"] = Convert.ToInt32(Request.QueryString["Post"]);
                    BindGrid();
                }
              
            }
            if (User.Identity.IsAuthenticated == false)
            {
                txtPostComment.Visible = false;
                RequiredFieldValidator6.Visible = false;
                btnComment.Visible = false;
                lblMsg.Visible = false;
            }
        }
        private void BindGrid()
        {
            Modikhana.BAL.TopicComments TopicCommentsObj = new Modikhana.BAL.TopicComments();
            CommentGridView.DataSource = TopicCommentsObj.SelectTopicCommentById(Convert.ToInt32(ViewState["PostID"]));
            CommentGridView.DataBind();
            TopicCommentsObj = null;
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblTopicComment topicCommentata = new Modikhana.DAL.tblTopicComment();
                topicCommentata.CreateedOn = DateTime.Now;

                String tempString = txtPostComment.Text;
                tempString = Server.HtmlEncode(tempString);
                tempString = tempString.Replace(" ", "&nbsp;");
                tempString = tempString.Replace("\r\n", "<br>");
                topicCommentata.TopicComment = tempString;
                
                topicCommentata.TopicId = Convert.ToInt32(Convert.ToInt32(ViewState["PostID"]));
                topicCommentata.UserId = Convert.ToInt32(Session["UserId"]);
                Modikhana.BAL.TopicComments TopicCommentsObj = new Modikhana.BAL.TopicComments();
                int Result = TopicCommentsObj.InsertTopicComment(topicCommentata);
                if (Result == 1)
                {
                    txtPostComment.Text = "";
                    BindGrid();
                }
                else
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Comment is not posted.";
                }
                TopicCommentsObj = null;
            }
            catch (Exception)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Comment is not posted.";
            }
        }

        protected void CommentGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.TopicComments TopicCommentsObj = new Modikhana.BAL.TopicComments();
            if (TopicCommentsObj.DeleteTopicComment(Convert.ToInt32(CommentGridView.DataKeys[e.RowIndex].Value)) == true)
            {
                BindGrid();
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Comment is not deleted.";
            }
        }
    }
}