using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Modikhana.Admin
{
    public partial class NewsList : System.Web.UI.Page
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
            Modikhana.BAL.News NewsObj = new Modikhana.BAL.News();
            GridNews.DataSource = NewsObj.SelectAllNews();
            GridNews.DataBind();
        }

        protected void GridNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridNews.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.News NewsObj = new Modikhana.BAL.News();
            if (DeleteImage(Convert.ToInt32(GridNews.DataKeys[e.RowIndex].Value)))
            {
                if (NewsObj.DeleteNews(Convert.ToInt32(GridNews.DataKeys[e.RowIndex].Value)) == true)
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
            else
            {
                fail.Style.Add("display", "");
            }
        }

        protected void GridNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddNews.aspx?NewsId=" + GridNews.DataKeys[e.RowIndex].Value);
        }

        private Boolean DeleteImage(Int32 NewsId)
        {
            try
            {
                Modikhana.DAL.tblNew newsData = new Modikhana.DAL.tblNew();
                Modikhana.BAL.News NewsObj = new Modikhana.BAL.News();
                newsData = NewsObj.SelectNewsById(NewsId);
                FileInfo _fileInfo = new FileInfo(Server.MapPath(newsData.NewsImagePath));
                if (_fileInfo.Exists)
                {
                    _fileInfo.Delete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}