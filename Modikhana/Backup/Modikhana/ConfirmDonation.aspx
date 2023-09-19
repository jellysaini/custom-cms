<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="ConfirmDonation.aspx.cs" Inherits="Modikhana.ConfirmDonation" %>

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
                            Confirm Donation
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <label>
                            You will be redirected to PayPal site to complete the donation.</label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr style="height: 35px;">
                    <td style="width: 80px;">
                        <label>
                            Name :</label>
                    </td>
                    <td>
                        <label>
                            <%Response.Write(Session["Dname"].ToString()); %></label>
                    </td>
                </tr>
                <tr style="height: 35px;">
                    <td style="width: 80px;">
                        <label>
                            Amount :</label>
                    </td>
                    <td>
                        <label>
                            <%Response.Write("$" + Session["DAmmount"].ToString()); %>
                        </label>
                    </td>
                </tr>
                <tr style="height: 70px;">
                    <td style="width: 80px; vertical-align: top;">
                        <label>
                            Purpose :</label>
                    </td>
                    <td>
                        <label>
                            <%Response.Write(Session["DPurpose"].ToString()); %></label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px; vertical-align: top;">
                        &nbsp;
                    </td>
                    <%
                        Modikhana.BAL.PaymentGatewayDetail PaymentGatewayDetailObj = new Modikhana.BAL.PaymentGatewayDetail();
                        Modikhana.DAL.tblPaymentGatewayDetail PaymentGatewayDetail = new Modikhana.DAL.tblPaymentGatewayDetail();
                        PaymentGatewayDetail = PaymentGatewayDetailObj.SelectPaymentGatewayDetail();
                        
                    %>
                    <td>
                        <input type="hidden" name="cmd" value="_donations" />
                        <input type="hidden" name="business" value="<%Response.Write(PaymentGatewayDetail.BusineesEmail); %>" />
                        <input type="hidden" name="lc" value="US" />
                        <input type="hidden" name="item_name" value="<%Response.Write(PaymentGatewayDetail.OrganizationName); %>" />
                        <input type="hidden" name="amount" value="<%Response.Write(Math.Round(Convert.ToDecimal(Session["DAmmount"].ToString()),2).ToString()); %>" />
                        <input type="hidden" name="currency_code" value="USD" />
                        <input type="hidden" name="no_note" value="0" />
                        <input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest" />
                        <input name="cancel_return" value='http://localhost:58462/DonationFail.aspx' type="hidden" />
                        <input name="return" value='http://localhost:58462/DonationSuccess.aspx' type="hidden" />
                        <asp:ImageButton runat="server" ID="btnpaypalconfim" ImageUrl="design/btn_donateCC_LG.gif"
                            PostBackUrl="https://www.sandbox.paypal.com/cgi-bin/webscr" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
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
        $("#Donation").addClass("tray-active");
    </script>
</asp:Content>
