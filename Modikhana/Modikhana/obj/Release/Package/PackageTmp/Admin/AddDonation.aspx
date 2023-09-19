<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="AddDonation.aspx.cs" Inherits="Modikhana.Admin.AddDonation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            Donation</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error.</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">
                <%
                    if (Request.QueryString["DonationId"] == null)
                    {
                        Response.Write("Create a Donation");
                    }
                    else
                    {
                        Response.Write("Edit Donation Data");
                    }
                %>
            </span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2">
                        <b>Please enter amount in dollar.</b>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="donation" ID="txtName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtName" ForeColor="Red" ValidationGroup="donation"
                            Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Amount:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="donation" ID="txtAmmount"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtAmmount" ForeColor="Red" ValidationGroup="donation"
                            Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ValidationGroup="donation"
                            Display="Dynamic" ControlToValidate="txtAmmount" Operator="DataTypeCheck" runat="server"
                            Type="Integer" ErrorMessage="Ammount must be number only."></asp:CompareValidator>
                    </td>
                </tr>
                <tr style="height: 36px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Receipt No:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="donation" ID="txtReceiptNo"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ControlToValidate="txtReceiptNo" ForeColor="Red" ValidationGroup="donation"
                            Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr style="height: 36px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Donation Type:
                        </label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" CssClass="drpNormal" ValidationGroup="donation"
                            ID="drpDonationType">
                            <asp:ListItem Text="By Check" Value="By Check" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Online Transfer" Value="Online Transfer"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth" style="vertical-align: top;">
                        <label class="lblNormal">
                            Purpose:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="MultiLine" ValidationGroup="donation" CssClass="txtAddress"
                            ID="txtPurpose"></asp:TextBox>
                        <asp:RequiredFieldValidator Style="margin-left: 5px;" ControlToValidate="txtPurpose"
                            ForeColor="Red" ValidationGroup="donation" Display="Dynamic" ID="RequiredFieldValidator7"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Save" CssClass="buttonSave" ValidationGroup="donation" runat="server"
                            ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button Text="Cancel" CssClass="buttonSave" CausesValidation="false" runat="server"
                            ID="btnCancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
