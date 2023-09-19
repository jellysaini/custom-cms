<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="ChangePassword.aspx.cs" Inherits="Modikhana.ChangePassword" %>

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
                            Change Password</h2>
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
                                    Old Password :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtLoginHeight" ValidationGroup="changepwd"
                                        TextMode="Password" ID="txtOldPassword"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="changepwd"
                                        ControlToValidate="txtOldPassword" ForeColor="Red" Display="Dynamic" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td style="width: 150px;">
                                    New Password :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtLoginHeight" ValidationGroup="changepwd"
                                        TextMode="Password" ID="txtNewPassword"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="changepwd"
                                        ControlToValidate="txtNewPassword" ForeColor="Red" Display="Dynamic" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td style="width: 150px;">
                                    Confirm Password :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtLoginHeight" ValidationGroup="changepwd"
                                        TextMode="Password" ID="txtConfirmPassword"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="changepwd"
                                        ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtConfirmPassword"
                                        ControlToCompare="txtNewPassword" ForeColor="Red" ValidationGroup="changepwd"
                                        Display="Dynamic" runat="server" ErrorMessage="Passwords do not match. "></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr style="height: 36px;">
                                <td style="width: 80px;">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnSave" SkinID="ChgPawdButton" ValidationGroup="changepwd"
                                        Text="Change Password" OnClick="btnSave_Click" />
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
    <script type="text/javascript">
        $("#Home").addClass("tray-active");
        $("#lnkChangePwd").addClass("nav-active");
    </script>
</asp:Content>
