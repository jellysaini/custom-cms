<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="MemberLogin.aspx.cs" Inherits="Modikhana.MemberLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="cols6-top" style="margin-left: auto; margin-right: auto;">
        </div>
        <div id="cols6" style="margin-left: auto; margin-right: auto;">
            <table border="0" style="margin-left: 15px;" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="2">
                        <h2>
                            Sign in</h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <table>
                            <tr style="height: 40px;">
                                <td style="width: 80px;">
                                    Username :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtLoginHeight" ValidationGroup="frmlogin"
                                        ID="txtUserName"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="frmlogin"
                                        ControlToValidate="txtUserName" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 34px;">
                                <td style="width: 80px;">
                                    Password :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtLoginHeight" ValidationGroup="frmlogin"
                                        ID="txtPassword" TextMode="Password"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="frmlogin"
                                        ControlToValidate="txtPassword" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 36px;">
                                <td style="width: 80px;">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkremmeberme" />
                                    &nbsp;Stay me signed in&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button runat="server" SkinID="NormalButton" ValidationGroup="frmlogin" Text="Sign in"
                                        ID="btnLogin" OnClick="btnLogin_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                    &nbsp;
                                </td>
                                <td style="text-align: right;">
                                    <asp:LinkButton runat="server" CausesValidation="false" Style="text-decoration: none; vertical-align: bottom;"
                                        ID="lnkForgotPassword" Text="Forgot your password ?" OnClick="lnkForgotPassword_Click"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top;">
                        <img src="design/loginpageicon.gif" alt="" style="margin-right: 20px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Style="margin-left: 100px;" runat="server" ForeColor="Red" ID="msg"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <!-- /cols2 -->
        <div id="cols6-bottom" style="margin-left: auto; margin-right: auto;">
        </div>
    </div>
</asp:Content>
