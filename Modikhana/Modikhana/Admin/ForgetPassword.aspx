<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs"
    Inherits="Modikhana.Admin.ForgetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Modikhana Charitable Trust</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta name="robots" content="index,follow" />
    <link rel="stylesheet" type="text/css" media="all" href="css/style.css" />
</head>
<body>
    <div>
        <div id="login_container">
            <div id="header">
                <div id="logo">
                    <h1>
                        <a href="/"></a>
                    </h1>
                </div>
            </div>
            <div id="forgetpassword" class="section">
                <div id="success" runat="server" style="display: none;" class="info_div">
                    <span class="ico_success">Yeah! email send successfully !</span></div>
                <div id="fail" runat="server" style="display: none;" class="info_div">
                    <span class="ico_cancel">Incorrect User Name</span></div>
                <form name="forgetpasswordform" id="forgetpasswordform" runat="server">
                <br />
                <label>
                    <strong>User Name :</strong></label>
                <asp:TextBox ID="username_login" runat="server" size="28" CssClass="input"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="username_login" ForeColor="Red" Display="Dynamic"
                    ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Button ID="save" runat="server" Text="Send..." class="loginbutton" OnClick="save_Click" />
                </form>
                <a href="Login.aspx" id="loginlink">Click Here for Login !</a>
            </div>
        </div>
    </div>
</body>
</html>
