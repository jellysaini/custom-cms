using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Modikhana
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserData(Convert.ToInt32(Session["UserId"]));
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
            txtEmail.Text = userData.EmailAddress;
            txtFirstName.Text = userData.FirstName;
            txtLastName.Text = userData.LastName;
            txtLoginName.Text = userData.LoginName;
            txtMobile.Text = userData.Mobile;
            txtPhone.Text = userData.Phone;
            txtState.Text = userData.StateName;
            UserObj = null;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblUser userData = new Modikhana.DAL.tblUser();
                userData.CityName = txtCity.Text;
                userData.CountryName = txtCountry.Text;
                userData.EmailAddress = txtEmail.Text;
                userData.FirstName = txtFirstName.Text;
                userData.LastName = txtLastName.Text;
                userData.Mobile = txtMobile.Text;
                userData.Phone = txtPhone.Text;
                userData.StateName = txtState.Text;
                userData.UserAddress = txtAddress.Text;
                userData.UserRole = 2;
                Modikhana.BAL.Users UserObj = new Modikhana.BAL.Users();
                userData.ID = Convert.ToInt32(Session["UserId"]);
                if (UserObj.UpdateMemberUser(userData) == true)
                {
                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "Your profile is updated successfully.";
                }
                else
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Your profile is not updated.";
                }

            }
            catch (Exception)
            {
            }

        }
    }
}