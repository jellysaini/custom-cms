<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="AddBankDetail.aspx.cs" Inherits="Modikhana.Admin.AddBankDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            Bank Detail Mangement</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">
                <%
                    if (Request.QueryString["BankinfoId"] == null)
                    {
                        Response.Write("Create a New  Bank Info");
                    }
                    else
                    {
                        Response.Write("Edit Bank");
                    }
                %></span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Bank Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="BankDeatil" ID="txtBankName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtBankName" ForeColor="Red" ValidationGroup="BankDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Account Holder:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="BankDeatil" ID="txtAccountHolder"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtAccountHolder" ForeColor="Red"
                            ValidationGroup="BankDeatil" Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Account Type:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="BankDeatil" CssClass="txtNormal" ID="txtAccountType"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtAccountType" ForeColor="Red" ValidationGroup="ConatctBankDeatilDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Account No:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="BankDeatil" CssClass="txtNormal" ID="txtAccountNo"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtAccountNo" ForeColor="Red" ValidationGroup="BankDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Branch Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="BankDeatil" CssClass="txtNormal" ID="txtBranchName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtBranchName" ForeColor="Red" ValidationGroup="BankDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            IFSC Code:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="BankDeatil" CssClass="txtNormal" ID="txtIFSCCode"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtIFSCCode" ForeColor="Red" ValidationGroup="BankDeatil"
                            Display="Dynamic" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Status:
                        </label>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="BankStatus" CssClass="noborder" />
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Save" CssClass="buttonSave" ValidationGroup="BankDeatil" runat="server"
                            ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button Text="Cancel" CssClass="buttonSave" CausesValidation="false" runat="server"
                            ID="btnCancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
