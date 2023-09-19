using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Modikhana.Admin
{
    public partial class BannerList : System.Web.UI.Page
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
            Modikhana.BAL.Banner BannerObj = new Modikhana.BAL.Banner();
            GridBanners.DataSource = BannerObj.SelectAllBanner();
            GridBanners.DataBind();
        }

        protected void GridBanners_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridBanners.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridBanners_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddBanner.aspx?BannerId=" + GridBanners.DataKeys[e.RowIndex].Value);
        }

        protected void GridBanners_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.Banner BannerObj = new Modikhana.BAL.Banner();
            if (DeleteImage(Convert.ToInt32(GridBanners.DataKeys[e.RowIndex].Value)))
            {
                if (BannerObj.DeleteBanner(Convert.ToInt32(GridBanners.DataKeys[e.RowIndex].Value)) == true)
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
        private Boolean DeleteImage(Int32 BannerId)
        {
            try
            {
                Modikhana.DAL.tblBanner bannerData = new Modikhana.DAL.tblBanner();
                Modikhana.BAL.Banner BannerObj = new Modikhana.BAL.Banner();
                bannerData = BannerObj.SelectBannerById(BannerId);
                FileInfo _fileInfo = new FileInfo(Server.MapPath(bannerData.BannerImagePath));
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