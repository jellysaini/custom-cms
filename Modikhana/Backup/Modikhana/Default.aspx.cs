using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindBannerRepeater();
            BindImageRepeater();
            BindNewsRepeater();
            BindOurWorkRepeater();
            BindEventskRepeater();
            BindForumsRepeater();

        }

        private void BindBannerRepeater()
        {
            Modikhana.BAL.Banner BannerObj  = new Modikhana.BAL.Banner();
            RepeaterBanner.DataSource = BannerObj.SelectAllBannerByTrueStatus();
            RepeaterBanner.DataBind();
        }

        private void BindImageRepeater()
        {
            Modikhana.BAL.Supposer SupposerObj = new Modikhana.BAL.Supposer();
            RepeaterImages.DataSource = SupposerObj.SelectAllSupposerByTrueStatus();
            RepeaterImages.DataBind();
        }

        private void BindNewsRepeater()
        {
            Modikhana.BAL.News NewsObj = new Modikhana.BAL.News();
            RepeaterNews.DataSource = NewsObj.SelectNNews(3);
            RepeaterNews.DataBind();
        }

        private void BindOurWorkRepeater()
        {
            Modikhana.BAL.OurWork OurWorkObj = new Modikhana.BAL.OurWork();
            RepeaterOurWork.DataSource = OurWorkObj.SelectNOurWork(10);
            RepeaterOurWork.DataBind();
        }

        private void BindEventskRepeater()
        {
            Modikhana.BAL.Event EventObj = new Modikhana.BAL.Event();
            RepeaterEvents.DataSource = EventObj.SelectNEvent(10);
            RepeaterEvents.DataBind();
        }

        private void BindForumsRepeater()
        {
            Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
            RepeaterForums.DataSource = DiscussionTopicObj.SelectNDiscussionTopic(10);
            RepeaterForums.DataBind();
        }
    }
}