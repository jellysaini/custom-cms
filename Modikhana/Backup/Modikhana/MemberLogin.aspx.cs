using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Modikhana
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCookies();
            }
        }

        private void GetCookies()
        {
            if (Request.Cookies["ModiUserName"] != null & Request.Cookies["ModiPassword"] != null)
            {
                if (Convert.ToString(Request.Cookies["ModiUserName"].Value) != "" & Convert.ToString(Request.Cookies["ModiPassword"].Value) != "")
                {
                    txtUserName.Text = Request.Cookies["ModiUserName"].Value.ToString().Trim();
                    txtPassword.Attributes.Add("value", Request.Cookies["ModiPassword"].Value.ToString().Trim());
                    chkremmeberme.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Modikhana.BAL.Login obj = new Modikhana.BAL.Login();
            List<Modikhana.DAL.tblUser> UserList = new List<Modikhana.DAL.tblUser>();
            UserList = obj.UserAuthentication(txtUserName.Text, txtPassword.Text);
            if (UserList.Count > 0)
            {
                Session["UserName"] = UserList[0].LoginName.ToString();
                Session["FirstName"] = UserList[0].FirstName.ToString();
                Session["UserId"] = UserList[0].ID.ToString();
                Session["UserRole"] = UserList[0].UserRole.ToString();
                if (chkremmeberme.Checked == true)
                {
                    HttpCookie cookieUserName = new HttpCookie("ModiUserName");
                    cookieUserName.Value = txtUserName.Text.Trim();
                    cookieUserName.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookieUserName);

                    HttpCookie cookiePassword = new HttpCookie("ModiPassword");
                    cookiePassword.Value = txtPassword.Text.Trim();
                    cookiePassword.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookiePassword);

                }
                else if (chkremmeberme.Checked == false)
                {
                    HttpContext.Current.Response.Cookies.Remove("ModiUserName");
                    Response.Cookies["ModiUserName"].Expires = DateTime.Now;

                    HttpContext.Current.Response.Cookies.Remove("ModiPassword");
                    Response.Cookies["ModiPassword"].Expires = DateTime.Now;
                }

                #region FormsAuthentication
                FormsAuthentication.Initialize();
                FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, txtUserName.Text, DateTime.Now, DateTime.Now.AddHours(1), false, UserList[0].UserRole.ToString(), FormsAuthentication.FormsCookiePath);
                string st = FormsAuthentication.Encrypt(tkt);
                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, st);
                Response.Cookies.Add(ck);
                #endregion

                if (Convert.ToInt32(UserList[0].UserRole) == 1)
                {
                    Response.Redirect("admin/Default.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                msg.Text = "Incorrect username/password";
            }
        }

        protected void lnkForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }
    }
}