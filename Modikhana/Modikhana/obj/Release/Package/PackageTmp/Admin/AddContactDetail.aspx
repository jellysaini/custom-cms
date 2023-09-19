<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="AddContactDetail.aspx.cs" Inherits="Modikhana.Admin.AddContactDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            Contact Detail Mangement</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">
                <%
                    if (Request.QueryString["ContactDetailId"] == null)
                    {
                        Response.Write("Create a New  Contact");
                    }
                    else
                    {
                        Response.Write("Edit Contact");
                    }
                %></span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Office Location:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="ConatctDeatil"
                            ID="txtOfficeLocation"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtOfficeLocation" ForeColor="Red"
                            ValidationGroup="ConatctDeatil" Display="Dynamic" ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Address:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="ConatctDeatil"
                            ID="txtAddress"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtAddress" ForeColor="Red" ValidationGroup="ConatctDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            City:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="ConatctDeatil" CssClass="txtNormal"
                            ID="txtCity"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtCity" ForeColor="Red" ValidationGroup="ConatctDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            State:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="ConatctDeatil" CssClass="txtNormal"
                            ID="txtState"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtState" ForeColor="Red" ValidationGroup="ConatctDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Telephone:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="ConatctDeatil" CssClass="txtNormal"
                            ID="txtTelephone"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtTelephone" ForeColor="Red" ValidationGroup="ConatctDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Mobile:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="ConatctDeatil" CssClass="txtNormal"
                            ID="txtMobile"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtMobile" ForeColor="Red" ValidationGroup="ConatctDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Email:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="ConatctDeatil" CssClass="txtNormal"
                            ID="txtEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="ConatctDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="ConatctDeatil"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                            ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invaild email Address."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Save" CssClass="buttonSave" ValidationGroup="ConatctDeatil" runat="server"
                            ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button Text="Cancel" CssClass="buttonSave" CausesValidation="false" runat="server"
                            ID="btnCancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
