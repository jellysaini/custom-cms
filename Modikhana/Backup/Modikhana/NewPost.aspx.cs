using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Modikhana
{
    public partial class NewPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PostId"] != null)
            {
                if (!IsPostBack)
                {
                    GetDiscussionTopicsListData(Convert.ToInt32(Request.QueryString["PostId"]));
                }
            }
        }

        private void GetDiscussionTopicsListData(Int32 DiscussionTopicsListDataId)
        {
            Modikhana.DAL.SelectDiscusstionTopicByIdResult discussionTopicData = new Modikhana.DAL.SelectDiscusstionTopicByIdResult();
            Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
            discussionTopicData = DiscussionTopicObj.SelectDiscussionTopicById(DiscussionTopicsListDataId);
            ckPostDescription.Text = discussionTopicData.TopicDescription;
            txtPostName.Text = discussionTopicData.TopicName;
            ViewState["PostStatus"] = discussionTopicData.TopicStatus;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblDiscussionTopic discussionTopicData = new Modikhana.DAL.tblDiscussionTopic();
                discussionTopicData.TopicDescription = ckPostDescription.Text;
                discussionTopicData.TopicName = txtPostName.Text;
                discussionTopicData.CreatedBy = Convert.ToInt32(Session["UserId"]);
                discussionTopicData.CreateedOn = DateTime.Now;

                Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
                if (Request.QueryString["PostId"] == null)
                {
                    discussionTopicData.TopicStatus = false;
                    if (DiscussionTopicObj.InsertDiscussionTopic(discussionTopicData) == true)
                    {
                        Clear();
                        lblmsg.ForeColor = Color.Green;
                        lblmsg.Text = "Your post has been created successfully. It will approve by admin.";
                    }
                    else
                    {
                        lblmsg.ForeColor = Color.Red;
                        lblmsg.Text = "Sorry your post is not created.Please contact to admin.";
                    }
                    DiscussionTopicObj = null;
                }
                else
                {
                    discussionTopicData.TopicStatus = Convert.ToBoolean(ViewState["PostStatus"]);
                    discussionTopicData.ID = Convert.ToInt32(Request.QueryString["PostId"]);
                    if (DiscussionTopicObj.UpdateDiscussionTopic(discussionTopicData) == true)
                    {
                        lblmsg.ForeColor = Color.Green;
                        lblmsg.Text = "Your post has been updated successfully.";
                        Response.Redirect("MyPost.aspx");
                    }
                    else
                    {
                        lblmsg.ForeColor = Color.Red;
                        lblmsg.Text = "Sorry your post is not updated.Please contact to admin.";
                    }
                }
            }
            catch (Exception)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Sorry there is an problem.Please contact to admin.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtPostName.Text = "";
            ckPostDescription.Text = "";
        }
    }
}