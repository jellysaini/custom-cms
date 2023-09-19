using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Modikhana.Admin
{
    public partial class OurWorkList : System.Web.UI.Page
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
            Modikhana.BAL.OurWork OurWorkObj = new Modikhana.BAL.OurWork();
            GridOurWork.DataSource = OurWorkObj.SelectAllOurWork();
            GridOurWork.DataBind();
        }

        protected void GridOurWork_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridOurWork.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridOurWork_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.OurWork OurWorkObj = new Modikhana.BAL.OurWork();
            if (DeleteImage(Convert.ToInt32(GridOurWork.DataKeys[e.RowIndex].Value)))
            {
                if (OurWorkObj.DeleteOurWork(Convert.ToInt32(GridOurWork.DataKeys[e.RowIndex].Value)) == true)
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

        protected void GridOurWork_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddOurWork.aspx?OurWorkId=" + GridOurWork.DataKeys[e.RowIndex].Value);
        }

        private Boolean DeleteImage(Int32 OurWorkId)
        {
            try
            {
                Modikhana.DAL.tblOurWork ourWorkData = new Modikhana.DAL.tblOurWork();
                Modikhana.BAL.OurWork OurWorkObj = new Modikhana.BAL.OurWork();
                ourWorkData = OurWorkObj.SelectOurWorkById(OurWorkId);
                FileInfo _fileInfo = new FileInfo(Server.MapPath(ourWorkData.WorkImagePath));
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