<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="Modikhana.Admin.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            Change Password</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error.</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">Change Password </span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Old Password:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ID="txtOldPassword" ValidationGroup="changepwd"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtOldPassword" ForeColor="Red" ValidationGroup="changepwd"
                            Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            New Password:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ID="txtNewPassword" ValidationGroup="changepwd"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtNewPassword" ForeColor="Red" ValidationGroup="changepwd"
                            Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Re-Enter Password:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ID="txtReEnterPassword" ValidationGroup="changepwd"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtReEnterPassword" ForeColor="Red"
                            ValidationGroup="changepwd" Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtReEnterPassword"
                            ControlToCompare="txtNewPassword" ForeColor="Red" ValidationGroup="changepwd"
                            Display="Dynamic" runat="server" ErrorMessage="Passwords do not match. "></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Save" CssClass="buttonSave" ValidationGroup="changepwd" runat="server"
                            ID="btnChange" OnClick="btnChange_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
