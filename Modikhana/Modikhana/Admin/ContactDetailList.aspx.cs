using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class ContactDetailList : System.Web.UI.Page
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
            Modikhana.BAL.ContactDetail ContactDetailObj = new Modikhana.BAL.ContactDetail();
            GridContactDetail.DataSource = ContactDetailObj.SelectAllContactDetail();
            GridContactDetail.DataBind();
        }

        protected void GridEvents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridContactDetail.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridEvents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.ContactDetail ContactDetailObj = new Modikhana.BAL.ContactDetail();
            if (ContactDetailObj.DeleteContactDetail(Convert.ToInt32(GridContactDetail.DataKeys[e.RowIndex].Value)) == true)
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

        protected void GridEvents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddContactDetail.aspx?ContactDetailId=" + GridContactDetail.DataKeys[e.RowIndex].Value);
        }
    }
}