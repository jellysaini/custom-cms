using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class UserList : System.Web.UI.Page
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
            Modikhana.BAL.Users UserObj = new Modikhana.BAL.Users();
            GridUsers.DataSource = UserObj.SelectAllUser();
            GridUsers.DataBind();
        }

        protected void GridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Modikhana.BAL.Users UserObj = new Modikhana.BAL.Users();
            if(UserObj.DeleteUser(Convert.ToInt32(GridUsers.DataKeys[e.RowIndex].Value))==true)
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

        protected void GridUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("AddUser.aspx?Id=" + GridUsers.DataKeys[e.RowIndex].Value);
        }
    }


}