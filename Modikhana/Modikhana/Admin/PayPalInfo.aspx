<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="PayPalInfo.aspx.cs" Inherits="Modikhana.Admin.PayPalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            PayPal Mangement</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Update Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">PayPal Information</span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Payment Gateway Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="PaymentGatewayDeatil"
                            ID="txtPaymentGatewayName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtPaymentGatewayName" ForeColor="Red"
                            ValidationGroup="PaymentGatewayDeatil" Display="Dynamic" ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Organization Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="PaymentGatewayDeatil"
                            ID="txtOrganizationName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtOrganizationName" ForeColor="Red"
                            ValidationGroup="PaymentGatewayDeatil" Display="Dynamic" ID="RequiredFieldValidator2"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Businees Email:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ValidationGroup="PaymentGatewayDeatil" CssClass="txtNormal"
                            ID="txtBusineesEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtBusineesEmail" ForeColor="Red"
                            ValidationGroup="PaymentGatewayDeatil" Display="Dynamic" ID="RequiredFieldValidator7"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtBusineesEmail" ForeColor="Red"
                            ValidationGroup="PaymentGatewayDeatil" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invaild email Address."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            PDT Token:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="PaymentGatewayDeatil"
                            ID="txtPDTToken"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtPDTToken" ForeColor="Red"
                            ValidationGroup="PaymentGatewayDeatil" Display="Dynamic" ID="RequiredFieldValidator3"
                            runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Status:
                        </label>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="PaymentGatewayStatus" CssClass="noborder" />
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Update" CssClass="buttonSave" ValidationGroup="PaymentGatewayDeatil"
                            runat="server" ID="btnSave" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
