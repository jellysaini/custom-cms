using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Modikhana.Admin
{
    public partial class SupposerList : System.Web.UI.Page
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
            Modikhana.BAL.Supposer SupposerObj = new Modikhana.BAL.Supposer();
            GridSupposers.DataSource = SupposerObj.SelectAllSupposer();
            GridSupposers.DataBind();
        }

        protected void GridSupposers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddSupposer.aspx?SupposerId=" + GridSupposers.DataKeys[e.RowIndex].Value);
        }

        protected void GridSupposers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridSupposers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridSupposers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.Supposer SupposerObj = new Modikhana.BAL.Supposer();
            if (DeleteImage(Convert.ToInt32(GridSupposers.DataKeys[e.RowIndex].Value)))
            {
                if (SupposerObj.DeleteSupposer(Convert.ToInt32(GridSupposers.DataKeys[e.RowIndex].Value)) == true)
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

        private Boolean DeleteImage(Int32 SupposerId)
        {
            try
            {
                Modikhana.DAL.tblSupposer supposerData = new Modikhana.DAL.tblSupposer();
                Modikhana.BAL.Supposer SupposerObj = new Modikhana.BAL.Supposer();
                supposerData = SupposerObj.SelectSupposerById(SupposerId);
                FileInfo _fileInfo = new FileInfo(Server.MapPath(supposerData.SupposerImagePath));
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