<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="PayPalDonationDetail.aspx.cs" Inherits="Modikhana.Admin.PayPalDonationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            PayPal Donation</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error.</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">PayPal Donation Detail </span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr style="height:30px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Name:
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblName"></asp:Label>
                    </td>
                </tr>
                <tr style="height:30px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Amount:
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblAmount"></asp:Label>
                    </td>
                </tr>
                <tr style="height:30px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Donation Type:
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblDonationType"></asp:Label>
                    </td>
                </tr>
                <tr style="height:30px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Donation Date:
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblDonationDate"></asp:Label>
                    </td>
                </tr>
                <tr style="height:30px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            PalPal Transaction Id:
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblPalPalTransactionId"></asp:Label>
                    </td>
                </tr>
                <tr style="height:30px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            PayPal Email:
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblPayPalEmail"></asp:Label>
                    </td>
                </tr>
                <tr style="height:30px;">
                    <td class="tdWidth" style="vertical-align: top;">
                        <label class="lblNormal">
                            PayPal First Name:
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblPayPalFirstName"></asp:Label>
                    </td>
                </tr>
                <tr style="height:30px;">
                    <td class="tdWidth" style="vertical-align: top;">
                        <label class="lblNormal">
                            PayPal Last Name:
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblPayPalLastName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Purpose:
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblPurpose"></asp:Label>
                    </td>
                </tr>
                <tr style="height:50px;">
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Back..." CssClass="buttonSave" CausesValidation="false" runat="server"
                            ID="btnCancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
