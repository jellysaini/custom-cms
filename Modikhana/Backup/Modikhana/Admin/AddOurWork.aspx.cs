using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Modikhana.Admin
{
    public partial class AddOurWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OurWorkId"] != null)
            {
                if (!IsPostBack)
                {
                    GetOurWorkData(Convert.ToInt32(Request.QueryString["OurWorkId"]));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblOurWork ourWorkData = new Modikhana.DAL.tblOurWork();
                #region SaveFile
                if (OurWorkImage.HasFile)
                {
                    #region Delete File
                    if (ViewState["OurWorkPath"] != null)
                    {
                        FileInfo _fileInfo = new FileInfo(Server.MapPath(ViewState["OurWorkPath"].ToString()));
                        if (_fileInfo.Exists)
                        {
                            _fileInfo.Delete();
                        }
                    }
                    #endregion

                    String FilePath = "../Upload/Event/" + Guid.NewGuid() + OurWorkImage.FileName;
                    String serverPath = Server.MapPath(FilePath);
                    OurWorkImage.SaveAs(serverPath);
                    ViewState["OurWorkPath"] = FilePath;
                }
                #endregion
                ourWorkData.WorkDescription = ckOurWorkDescription.Text;
                ourWorkData.WorkImagePath = Convert.ToString(ViewState["OurWorkPath"]);
                ourWorkData.WorkName = txtOurWorkName.Text;
                ourWorkData.WorkOrder = Convert.ToInt32(txtOrder.Text);
                ourWorkData.WorkStatus = OurWorkStatus.Checked;
                Modikhana.BAL.OurWork OurWorkObj = new Modikhana.BAL.OurWork();
                if (Request.QueryString["OurWorkId"] == null)
                {
                    int Result = OurWorkObj.InsertOurWork(ourWorkData);
                    if (Result == 1)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("OurWorkList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    ourWorkData = null;
                }
                else
                {
                    ourWorkData.ID = Convert.ToInt32(Request.QueryString["OurWorkId"]);
                    if (OurWorkObj.UpdateOurWork(ourWorkData) == true)
                    {
                        Response.Redirect("OurWorkList.aspx");
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

            ViewState["OurWorkPath"] = null;
        }

        private void GetOurWorkData(Int32 OurWorkId)
        {
            ViewState["OurWorkPath"] = null;
            Modikhana.DAL.tblOurWork ourWorkData = new Modikhana.DAL.tblOurWork();
            Modikhana.BAL.OurWork OurWorkObj = new Modikhana.BAL.OurWork();
            ourWorkData = OurWorkObj.SelectOurWorkById(OurWorkId);
            ckOurWorkDescription.Text = ourWorkData.WorkDescription;
            ViewState["OurWorkPath"] = ourWorkData.WorkImagePath;
            txtOurWorkName.Text = ourWorkData.WorkName;
            txtOrder.Text = ourWorkData.WorkOrder.ToString();
            OurWorkStatus.Checked = Convert.ToBoolean(ourWorkData.WorkStatus);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OurWorkList.aspx");
        }
    }
}