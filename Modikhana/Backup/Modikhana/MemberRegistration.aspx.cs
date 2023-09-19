using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Security;

namespace Modikhana
{
    public partial class MemberRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNewsRepeater();
            }
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
                userData.LoginName = txtLoginName.Text;
                userData.Mobile = txtMobile.Text;
                userData.Phone = txtPhone.Text;
                userData.StateName = txtState.Text;
                userData.UserAddress = txtAddress.Text;
                userData.UserPassword = txtPassword.Text;
                userData.UserRole = 2;
                userData.UserStatus = true;
                Modikhana.BAL.Users UserObj = new Modikhana.BAL.Users();
                int Result = UserObj.InsertUser(userData);
                if (Result == 1)
                {
                    Modikhana.BAL.Login obj = new Modikhana.BAL.Login();
                    List<Modikhana.DAL.tblUser> UserList = new List<Modikhana.DAL.tblUser>();
                    UserList = obj.UserAuthentication(txtLoginName.Text, txtPassword.Text);
                    if (UserList.Count > 0)
                    {
                        Session["UserName"] = UserList[0].LoginName.ToString();
                        Session["UserId"] = UserList[0].ID.ToString();
                        Session["UserRole"] = UserList[0].UserRole.ToString();

                        #region FormsAuthentication
                        FormsAuthentication.Initialize();
                        FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, txtLoginName.Text, DateTime.Now, DateTime.Now.AddHours(1), false, UserList[0].UserRole.ToString(), FormsAuthentication.FormsCookiePath);
                        string st = FormsAuthentication.Encrypt(tkt);
                        HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, st);
                        Response.Cookies.Add(ck);
                        #endregion

                        Response.Redirect("Default.aspx");
                    }
                    obj = null;
                }
                else if (Result == 2)
                {
                    lblalreadyexist.Text = txtLoginName.Text + " is not available";
                }
                else
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "You have not registered. Please contact to admin.";
                }
                UserObj = null;

            }
            catch (Exception)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "There is a problem. Please contact to admin.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtCity.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtLoginName.Text = "";
            txtMobile.Text = "";
            txtPhone.Text = "";
            txtState.Text = "";
            txtAddress.Text = "";
            txtPassword.Text = "";
            lblalreadyexist.Style.Add("display", "none");
            lblalreadyexist.Text = "";
        }

        protected void lnkalreadyexist_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLoginName.Text == "")
                {
                    lblalreadyexist.Style.Add("display", "inline");
                    lblalreadyexist.ForeColor = Color.Red;
                    lblalreadyexist.Text = "Login name is empty.";
                }
                else
                {
                    Modikhana.BAL.Login LoginObj = new Modikhana.BAL.Login();
                    int a = LoginObj.AlreadyExist(txtLoginName.Text);
                    if (a == 0)
                    {
                        lblalreadyexist.Style.Add("display", "inline");
                        lblalreadyexist.ForeColor = Color.Green;
                        lblalreadyexist.Text = txtLoginName.Text + " is available";
                    }
                    else
                    {
                        lblalreadyexist.Style.Add("display", "inline");
                        lblalreadyexist.ForeColor = Color.Red;
                        lblalreadyexist.Text = txtLoginName.Text + " is not available";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void BindNewsRepeater()
        {
            Modikhana.BAL.News NewsObj = new Modikhana.BAL.News();
            RepeaterNews.DataSource = NewsObj.SelectNNews(8);
            RepeaterNews.DataBind();
        }
    }
}