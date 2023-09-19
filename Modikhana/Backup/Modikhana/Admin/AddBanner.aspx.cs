using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Modikhana.Admin
{
    public partial class AddBanner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["BannerId"] != null)
            {
                if (!IsPostBack)
                {
                    GetBannerData(Convert.ToInt32(Request.QueryString["BannerId"]));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblBanner bannerData = new Modikhana.DAL.tblBanner();
                bannerData.BannerDescription = ckBannerDescription.Text;
                #region SaveFile
                if (BannerImage.HasFile)
                {
                    #region Delete File
                    if (ViewState["BannerPath"] != null)
                    {
                        FileInfo _fileInfo = new FileInfo(Server.MapPath(ViewState["BannerPath"].ToString()));
                        if (_fileInfo.Exists)
                        {
                            _fileInfo.Delete();
                        }
                    }
                    #endregion

                    String FilePath = "../Upload/Banner/" + Guid.NewGuid() + BannerImage.FileName;
                    String serverPath = Server.MapPath(FilePath);
                    BannerImage.SaveAs(serverPath);
                    ViewState["BannerPath"] = FilePath;
                }
                #endregion
                bannerData.BannerImagePath = Convert.ToString(ViewState["BannerPath"]);
                bannerData.BannerName = txtBannerName.Text;
                bannerData.BannerOrder = Convert.ToInt32(txtOrder.Text);
                bannerData.BannerStatus = BannerStatus.Checked;
                Modikhana.BAL.Banner BannerObj = new Modikhana.BAL.Banner();
                if (Request.QueryString["BannerId"] == null)
                {
                    int Result = BannerObj.InsertBanner(bannerData);
                    if (Result == 1)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("BannerList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    bannerData = null;
                }
                else
                {
                    bannerData.ID = Convert.ToInt32(Request.QueryString["BannerId"]);
                    if (BannerObj.UpdateBanner(bannerData) == true)
                    {
                        Response.Redirect("BannerList.aspx");
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

            ViewState["BannerPath"] = null;
        }

        private void GetBannerData(Int32 BannerId)
        {
            ViewState["BannerPath"] = null;
            Modikhana.DAL.tblBanner bannerData = new Modikhana.DAL.tblBanner();
            Modikhana.BAL.Banner BannerObj = new Modikhana.BAL.Banner();
            bannerData = BannerObj.SelectBannerById(BannerId);
            ckBannerDescription.Text = bannerData.BannerDescription;
            ViewState["BannerPath"] = bannerData.BannerImagePath;
            txtBannerName.Text = bannerData.BannerName;
            txtOrder.Text = bannerData.BannerOrder.ToString();
            BannerStatus.Checked = Convert.ToBoolean(bannerData.BannerStatus);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BannerList.aspx");
        }
    }
}