using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class AddDiscussionTopics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["DiscussionTopicId"] != null)
            {
                if (!IsPostBack)
                {
                    GetDiscussionTopicsListData(Convert.ToInt32(Request.QueryString["DiscussionTopicId"]));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblDiscussionTopic discussionTopicData = new Modikhana.DAL.tblDiscussionTopic();
                discussionTopicData.TopicDescription = ckDiscussionTopicsDescription.Text;
                discussionTopicData.TopicName = txtDiscussionTopicsName.Text;
                discussionTopicData.CreatedBy = Convert.ToInt32(Session["UserId"]);
                discussionTopicData.CreateedOn = DateTime.Now;
                discussionTopicData.TopicStatus = Convert.ToBoolean(chkDiscussionTopicsStatus.Checked);
                Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
                if (Request.QueryString["DiscussionTopicId"] == null)
                {
                    
                    if (DiscussionTopicObj.InsertDiscussionTopic(discussionTopicData)==true)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("DiscussionTopicsList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    DiscussionTopicObj = null;
                }
                else
                {
                    discussionTopicData.ID = Convert.ToInt32(Request.QueryString["DiscussionTopicId"]);
                    if (DiscussionTopicObj.UpdateDiscussionTopic(discussionTopicData) == true)
                    {
                        Response.Redirect("DiscussionTopicsList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                }
            }
            catch (Exception)
            {
                fail.Style.Add("display", "");
            }
        }

        private void GetDiscussionTopicsListData(Int32 DiscussionTopicsListDataId)
        {
            Modikhana.DAL.SelectDiscusstionTopicByIdResult discussionTopicData = new Modikhana.DAL.SelectDiscusstionTopicByIdResult();
            Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
            discussionTopicData = DiscussionTopicObj.SelectDiscussionTopicById(DiscussionTopicsListDataId);
            ckDiscussionTopicsDescription.Text = discussionTopicData.TopicDescription;
            txtDiscussionTopicsName.Text = discussionTopicData.TopicName;
            chkDiscussionTopicsStatus.Checked = Convert.ToBoolean(discussionTopicData.TopicStatus);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DiscussionTopicsList.aspx");
        }
    }
}