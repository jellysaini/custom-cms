using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                if (!IsPostBack)
                {
                    GetUserData(Convert.ToInt32(Request.QueryString["Id"]));
                    txtLoginName.Enabled = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblUser userData = new Modikhana.DAL.tblUser();
                userData.CityName = txtCity.Text;
                userData.CountryName = txtCountry.Text;
                userData.EmailAddress = txtEmailAddress.Text;
                userData.FirstName = txtFirstName.Text;
                userData.LastName = txtLastName.Text;
                userData.LoginName = txtLoginName.Text;
                userData.Mobile = txtMobile.Text;
                userData.Phone = txtPhone.Text;
                userData.StateName = txtState.Text;
                userData.UserAddress = txtAddress.Text;
                userData.UserPassword = txtPassword.Text;
                userData.UserRole = 2;
                userData.UserStatus = UserStatus.Checked;
                Modikhana.BAL.Users UserObj = new Modikhana.BAL.Users();
                if (Request.QueryString["Id"] == null)
                {
                    int Result = UserObj.InsertUser(userData);
                    if (Result == 1)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("UserList.aspx");
                    }
                    else if (Result == 2)
                    {
                        allready.Style.Add("display", "");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    UserObj = null;
                }
                else
                {
                    userData.ID = Convert.ToInt32(Request.QueryString["Id"]);
                    if (UserObj.UpdateUser(userData) == true)
                    {
                        Response.Redirect("UserList.aspx");
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

        private void GetUserData(Int32 UserId)
        {
            Modikhana.DAL.tblUser userData = new Modikhana.DAL.tblUser();
            Modikhana.BAL.Users UserObj = new Modikhana.BAL.Users();
            userData = UserObj.SelectUserById(UserId);
            txtAddress.Text = userData.UserAddress;
            txtCity.Text = userData.CityName;
            txtCountry.Text = userData.CountryName;
            txtEmailAddress.Text = userData.EmailAddress;
            txtFirstName.Text = userData.FirstName;
            txtLastName.Text = userData.LastName;
            txtLoginName.Text = userData.LoginName;
            txtMobile.Text = userData.Mobile;
            txtPassword.Text = userData.UserPassword;
            txtPhone.Text = userData.Phone;
            txtRenterPassword.Text = userData.UserPassword;
            txtState.Text = userData.StateName;
            UserStatus.Checked = Convert.ToBoolean(userData.UserStatus);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserList.aspx");
        }
    }
}