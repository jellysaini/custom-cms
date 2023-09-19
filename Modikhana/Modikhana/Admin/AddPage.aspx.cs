using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class AddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PageId"] != null)
            {
                if (!IsPostBack)
                {
                    GetPageData(Convert.ToInt32(Request.QueryString["PageId"]));
                    if (Convert.ToInt32(Request.QueryString["PageId"]) <= 7)
                    {
                        txtLinkName.Enabled = false;
                        txtPageName.Enabled = false;
                    }

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblContentManagement contentPageData = new Modikhana.DAL.tblContentManagement();
                contentPageData.LinkContent = ckPageContent.Text;
                contentPageData.LinkName = txtLinkName.Text;
                contentPageData.LinkOrder = Convert.ToInt32(txtOrder.Text);
                contentPageData.LinkStatus = Convert.ToBoolean(chkPageStatus.Checked);
                Modikhana.BAL.ContentManagement ContentManagementObj = new Modikhana.BAL.ContentManagement();
                if (Request.QueryString["PageId"] == null)
                {
                    int Result = ContentManagementObj.InsertContentPage(contentPageData);
                    if (Result == 1)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("PagesList.aspx");
                    }
                    else if (Result == 2)
                    {
                        allready.Style.Add("display", "");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    ContentManagementObj = null;
                }
                else
                {
                    contentPageData.ID = Convert.ToInt32(Request.QueryString["PageId"]);
                    if (ContentManagementObj.UpdateContentPage(contentPageData) == true)
                    {
                        Response.Redirect("PagesList.aspx");
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

        private void GetPageData(Int32 PageId)
        {
            Modikhana.DAL.tblContentManagement contentPageData = new Modikhana.DAL.tblContentManagement();
            Modikhana.BAL.ContentManagement ContentManagementObj = new Modikhana.BAL.ContentManagement();
            contentPageData = ContentManagementObj.SelectByPageId(PageId);
            ckPageContent.Text = contentPageData.LinkContent;
            txtLinkName.Text = contentPageData.LinkName;
            txtOrder.Text = contentPageData.LinkOrder.ToString();
            txtPageName.Text = contentPageData.LinkName;
            chkPageStatus.Checked = Convert.ToBoolean(contentPageData.LinkStatus);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagesList.aspx");
        }
    }
}