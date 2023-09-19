using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Modikhana.Admin
{
    public partial class AddSupposer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SupposerId"] != null)
            {
                if (!IsPostBack)
                {
                    GetBannerData(Convert.ToInt32(Request.QueryString["SupposerId"]));
                }
            }
        }

        private void GetBannerData(Int32 SupposerId)
        {
            ViewState["SupposerPath"] = null;
            Modikhana.DAL.tblSupposer supposerData = new Modikhana.DAL.tblSupposer();
            Modikhana.BAL.Supposer SupposerObj = new Modikhana.BAL.Supposer();
            supposerData = SupposerObj.SelectSupposerById(SupposerId);

            ViewState["SupposerPath"] = supposerData.SupposerImagePath;
            txtSupposerName.Text = supposerData.SupposerName;

            SupposerStatus.Checked = Convert.ToBoolean(supposerData.SupposerStatus);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblSupposer supposerData = new Modikhana.DAL.tblSupposer();
                #region SaveFile
                if (SupposerImage.HasFile)
                {
                    #region Delete File
                    if (ViewState["SupposerPath"] != null)
                    {
                        FileInfo _fileInfo = new FileInfo(Server.MapPath(ViewState["SupposerPath"].ToString()));
                        if (_fileInfo.Exists)
                        {
                            _fileInfo.Delete();
                        }
                    }
                    #endregion

                    String FilePath = "../Upload/Supposer/" + Guid.NewGuid() + SupposerImage.FileName;
                    String serverPath = Server.MapPath(FilePath);
                    SupposerImage.SaveAs(serverPath);
                    ViewState["SupposerPath"] = FilePath;
                }
                #endregion
                supposerData.SupposerImagePath = Convert.ToString(ViewState["SupposerPath"]);
                supposerData.SupposerName = txtSupposerName.Text;
                supposerData.SupposerStatus = SupposerStatus.Checked;
                Modikhana.BAL.Supposer SupposerObj = new Modikhana.BAL.Supposer();
                if (Request.QueryString["SupposerId"] == null)
                {
                    int Result = SupposerObj.InsertSupposer(supposerData);
                    if (Result == 1)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("SupposerList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    supposerData = null;
                }
                else
                {
                    supposerData.ID = Convert.ToInt32(Request.QueryString["SupposerId"]);
                    if (SupposerObj.UpdateSupposer(supposerData) == true)
                    {
                        Response.Redirect("SupposerList.aspx");
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

            ViewState["SupposerPath"] = null;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupposerList.aspx");
        }
    }
}