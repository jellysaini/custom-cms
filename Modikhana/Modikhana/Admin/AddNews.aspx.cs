using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Modikhana.Admin
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["NewsId"] != null)
            {
                if (!IsPostBack)
                {
                    GetNewsData(Convert.ToInt32(Request.QueryString["NewsId"]));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblNew newsData = new Modikhana.DAL.tblNew();
                #region SaveFile
                if (NewsImage.HasFile)
                {
                    #region Delete File
                    if (ViewState["NewsPath"] != null)
                    {
                        FileInfo _fileInfo = new FileInfo(Server.MapPath(ViewState["NewsPath"].ToString()));
                        if (_fileInfo.Exists)
                        {
                            _fileInfo.Delete();
                        }
                    }
                    #endregion

                    String FilePath = "../Upload/News/" + Guid.NewGuid() + NewsImage.FileName;
                    String serverPath = Server.MapPath(FilePath);
                    NewsImage.SaveAs(serverPath);
                    ViewState["NewsPath"] = FilePath;
                }
                #endregion

                newsData.NewsDescription = ckNewsDescription.Text;
                newsData.NewsImagePath = Convert.ToString(ViewState["NewsPath"]);
                newsData.NewsName = txtNewsName.Text;
                newsData.NewsOrder = Convert.ToInt32(txtOrder.Text);
                newsData.NewsStatus= chkNewsStatus.Checked;
                Modikhana.BAL.News NewsObj = new Modikhana.BAL.News();
                if (Request.QueryString["NewsId"] == null)
                {
                    int Result = NewsObj.InsertNews(newsData);
                    if (Result == 1)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("NewsList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    newsData = null;
                }
                else
                {
                    newsData.ID = Convert.ToInt32(Request.QueryString["NewsId"]);
                    if (NewsObj.UpdateNews(newsData) == true)
                    {
                        Response.Redirect("NewsList.aspx");
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

            ViewState["NewsPath"] = null;
        }

        private void GetNewsData(Int32 NewsId)
        {
            ViewState["NewsPath"] = null;
            Modikhana.DAL.tblNew newData = new Modikhana.DAL.tblNew();
            Modikhana.BAL.News NewsObj = new Modikhana.BAL.News();
            newData = NewsObj.SelectNewsById(NewsId);
            ckNewsDescription.Text = newData.NewsDescription;
            ViewState["NewsPath"] = newData.NewsImagePath;
            txtNewsName.Text = newData.NewsName;
            txtOrder.Text = newData.NewsOrder.ToString();
            chkNewsStatus.Checked = Convert.ToBoolean(newData.NewsStatus);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsList.aspx");
        }
    }
}