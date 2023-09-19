<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="ForgetPassword.aspx.cs" Inherits="Modikhana.ForgetPassword" %>

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
                            Forgot Password</h2>
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
                            <tr style="height: 30px;">
                                <td style="width: 150px;">
                                    Login Name :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtLoginHeight" ValidationGroup="forgot" 
                                        ID="txtLoginName"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="forgot"
                                        ControlToValidate="txtLoginName" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 36px;">
                                <td style="width: 80px;">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnSave" SkinID="NormalButton" ValidationGroup="forgot"
                                        Text="Send" onclick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top;">
                        <img src="design/password.gif" alt="" style="margin-right: 20px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Style="margin-left: 150px;" runat="server" ForeColor="Red" ID="msg"></asp:Label>
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
