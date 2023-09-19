using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana
{
    public partial class NewsRoom : System.Web.UI.Page
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
            GridViewNews.DataSource = NewsObj.SelectAllNewsByTrueStatus();
            GridViewNews.DataBind();
        }

        protected void GridViewNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewNews.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}