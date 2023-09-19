<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Modikhana.Admin.Login" %>

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
    <div id="login_container">
        <div id="header">
            <div id="logo">
                <h1>
                    <a href="/"></a>
                </h1>
            </div>
        </div>
        <div id="login" class="section">
            <div id="fail" runat="server" style="display: none;" class="info_div">
                <span class="ico_cancel">Incorrect username or password!</span></div>
            <form name="loginform" id="loginform" runat="server">
            <br />
            <label>
                <strong>Username:</strong></label>
            <asp:TextBox ID="username_login" runat="server" size="28" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="username_login" ForeColor="Red" Display="Dynamic"
                ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
            <label>
                <strong>Password:</strong></label>
            <asp:TextBox ID="user_pass" runat="server" TextMode="Password" size="29" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="user_pass" ForeColor="Red" Display="Dynamic"
                ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
            <strong>Remember Me</strong><asp:CheckBox runat="server" CssClass="input noborder"
                ID="chkRemember" />
            <br />
            <asp:Button ID="save" runat="server" Text="Log In" class="loginbutton" OnClick="save_Click" />
            </form>
            <a href="ForgetPassword.aspx" id="passwordrecoverylink">Forgot your username or password?</a>
        </div>
    </div>
</body>
</html>
