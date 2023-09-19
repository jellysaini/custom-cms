using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Modikhana.Admin
{
    public partial class Login : System.Web.UI.Page
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
            if (Request.Cookies["ModiUserNameAdmin"] != null & Request.Cookies["ModiPasswordAdmin"] != null)
            {
                if (Convert.ToString(Request.Cookies["ModiUserNameAdmin"].Value) != "" & Convert.ToString(Request.Cookies["ModiPasswordAdmin"].Value) != "")
                {
                    username_login.Text = Request.Cookies["ModiUserNameAdmin"].Value.ToString().Trim();
                    user_pass.Attributes.Add("value", Request.Cookies["ModiPasswordAdmin"].Value.ToString().Trim());
                    chkRemember.Checked = true;
                }
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            Modikhana.BAL.Login obj = new Modikhana.BAL.Login();
            List<Modikhana.DAL.tblUser> UserList = new List<Modikhana.DAL.tblUser>();
            UserList = obj.UserAuthentication(username_login.Text, user_pass.Text);
            if (UserList.Count > 0)
            {
                if (Convert.ToInt32(UserList[0].UserRole) == 1)
                {
                    Session["UserName"] = UserList[0].LoginName.ToString();
                    Session["FirstName"] = UserList[0].FirstName.ToString();
                    Session["UserId"] = UserList[0].ID.ToString();
                    Session["UserRole"] = UserList[0].UserRole.ToString();
                    if (chkRemember.Checked == true)
                    {
                        HttpCookie cookieUserName = new HttpCookie("ModiUserNameAdmin");
                        cookieUserName.Value = username_login.Text.Trim();
                        cookieUserName.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookieUserName);

                        HttpCookie cookiePassword = new HttpCookie("ModiPasswordAdmin");
                        cookiePassword.Value = user_pass.Text.Trim();
                        cookiePassword.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookiePassword);

                    }
                    else if (chkRemember.Checked == false)
                    {
                        HttpContext.Current.Response.Cookies.Remove("ModiUserNameAdmin");
                        Response.Cookies["ModiUserNameAdmin"].Expires = DateTime.Now;

                        HttpContext.Current.Response.Cookies.Remove("ModiPasswordAdmin");
                        Response.Cookies["ModiPasswordAdmin"].Expires = DateTime.Now;
                    }

                    #region FormsAuthentication
                    FormsAuthentication.Initialize();
                    FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, username_login.Text, DateTime.Now, DateTime.Now.AddHours(1), false, UserList[0].UserRole.ToString(), FormsAuthentication.FormsCookiePath);
                    string st = FormsAuthentication.Encrypt(tkt);
                    HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, st);
                    Response.Cookies.Add(ck);
                    #endregion

                    Response.Redirect("Default.aspx");
                }
                else
                {
                    fail.Style.Add("display", "inline");
                }
            }
            else
            {
                fail.Style.Add("display", "inline");
            }
        }
    }
}