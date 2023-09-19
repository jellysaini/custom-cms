<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="AddUser.aspx.cs" Inherits="Modikhana.Admin.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            User</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error.</span></div>
        <div id="allready" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, Login name allready exist.</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">
                <%
                    if (Request.QueryString["id"] == null)
                    {
                        Response.Write("Create an Account");
                    }
                    else
                    {
                        Response.Write("Edit User Account");
                    }
                %>
            </span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            First name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtFirstName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtFirstName" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Last name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtLastName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtLastName" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Email address:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtEmailAddress"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtEmailAddress" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtEmailAddress" ForeColor="Red"
                            ValidationGroup="registerUser" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invaild email Address."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Desired Login Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtLoginName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtLoginName" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Choose a password:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtPassword"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Re-enter password:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtRenterPassword"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtRenterPassword" ForeColor="Red"
                            ValidationGroup="registerUser" Display="Dynamic" ID="RequiredFieldValidator6"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtRenterPassword"
                            ControlToCompare="txtPassword" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" runat="server" ErrorMessage="Passwords do not match. "></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth" style="vertical-align: top;">
                        <label class="lblNormal">
                            Address:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="MultiLine" ValidationGroup="registerUser" CssClass="txtAddress"
                            ID="txtAddress"></asp:TextBox>
                        <asp:RequiredFieldValidator Style="margin-left: 5px;" ControlToValidate="txtAddress"
                            ForeColor="Red" ValidationGroup="registerUser" Display="Dynamic" ID="RequiredFieldValidator7"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Mobile No:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtMobile"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtMobile" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Phone No:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="registerUser" CssClass="txtNormal" ID="txtPhone"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Country:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtCountry"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtCountry" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            State:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtState"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtState" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            City:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="registerUser" ID="txtCity"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtCity" ForeColor="Red" ValidationGroup="registerUser"
                            Display="Dynamic" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Status:
                        </label>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="UserStatus" CssClass="noborder" />
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Save" CssClass="buttonSave" ValidationGroup="registerUser" runat="server"
                            ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button Text="Cancel" CssClass="buttonSave" CausesValidation="false" runat="server"
                            ID="btnCancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
