using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class ContactUs : System.Web.UI.Page
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
            Modikhana.BAL.ContactUs ContactObj = new Modikhana.BAL.ContactUs();
            GridContactUs.DataSource = ContactObj.SelectAllContactUs();
            GridContactUs.DataBind();

        }

        protected void GridContactUs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridContactUs.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridContactUs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.ContactUs FeedbackObj = new Modikhana.BAL.ContactUs();
            if (FeedbackObj.DeleteContactUs(Convert.ToInt32(GridContactUs.DataKeys[e.RowIndex].Value)) == true)
            {
                BindGrid();
                success.Style.Add("display", "");
            }
            else
            {
                fail.Style.Add("display", "");
            }
        }

        protected void GridContactUs_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("MessageReply.aspx?id=" + GridContactUs.DataKeys[e.RowIndex].Value + "&page=contact");
        }
    }
}