<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="EmailSetting.aspx.cs" Inherits="Modikhana.Admin.EmailSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <h2 class="ico_mug">
            Email Setting Mangement</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">Email Setting</span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            User Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="EmailSetting" ID="txtUserName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtUserName" ForeColor="Red" ValidationGroup="EmailSetting"
                            Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Password :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="EmailSetting" ID="txtPassword"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="EmailSetting"
                            Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Incoming Mail Server :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="EmailSetting" ID="txtIncomingEmailServer"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtIncomingEmailServer" ForeColor="Red"
                            ValidationGroup="EmailSetting" Display="Dynamic" ID="RequiredFieldValidator4"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Outgoing Mail Server :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="EmailSetting" ID="txtOutgoingEmailServer"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtOutgoingEmailServer" ForeColor="Red"
                            ValidationGroup="EmailSetting" Display="Dynamic" ID="RequiredFieldValidator5"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Incoming Port Number :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="EmailSetting" ID="txtIncomingPortNumber"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtIncomingPortNumber" ForeColor="Red"
                            ValidationGroup="EmailSetting" Display="Dynamic" ID="RequiredFieldValidator6"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ValidationGroup="EmailSetting"
                            Display="Dynamic" ControlToValidate="txtIncomingPortNumber" Operator="DataTypeCheck"
                            runat="server" Type="Integer" ErrorMessage="Port # must be interger."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Outgoing Port Number :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="EmailSetting" ID="txtOutgoingPortNumber"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtOutgoingPortNumber" ForeColor="Red"
                            ValidationGroup="EmailSetting" Display="Dynamic" ID="RequiredFieldValidator7"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" ForeColor="Red" ValidationGroup="EmailSetting"
                            Display="Dynamic" ControlToValidate="txtOutgoingPortNumber" Operator="DataTypeCheck"
                            runat="server" Type="Integer" ErrorMessage="Port # must be interger."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Is SSl Enable :
                        </label>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="chkIsSSLEnable" CssClass="noborder" />
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Save" CssClass="buttonSave" ValidationGroup="EmailSetting" runat="server"
                            ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button Text="Cancel" CssClass="buttonSave" CausesValidation="false" runat="server"
                            ID="btnCancel" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
