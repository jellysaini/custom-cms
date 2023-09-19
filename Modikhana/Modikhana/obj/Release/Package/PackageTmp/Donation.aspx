<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="Donation.aspx.cs" Inherits="Modikhana.Donation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%
        Modikhana.BAL.ContentManagement objPage = new Modikhana.BAL.ContentManagement();
        Modikhana.DAL.tblContentManagement PageData = new Modikhana.DAL.tblContentManagement();
        PageData = objPage.SelectByPageId(5);
    %>
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <div style="float: left; width: 660px;">
            <table style="margin-left: 15px;">
                <tr>
                    <td>
                        <h2>
                            <%
                                Response.Write(PageData.LinkName.ToString());
                            %>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>
                            <%
                                Response.Write(PageData.LinkContent.ToString());
                                PageData = null;
                                objPage = null;
                            %>
                        </p>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: right; margin-right: 20px; width: 270px">
            <img src="design/donations.jpg" alt="" />
        </div>
        <div style="clear: both;">
            <table border="0" cellspacing="0" cellpadding="0" style="margin: 30px;" width="100%">
                <tr>
                    <td>
                        <div class="col">
                            <h3>
                                <a href="#">Online Transfer</a></h3>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList runat="server" ID="DataListBankInfo" Width="100%" RepeatColumns="2"
                            Style="margin: 10px 60px 10px 60px;">
                            <ItemTemplate>
                                <div style="margin-bottom: 20px;">
                                    <div>
                                        <label>
                                            Bank :</label>
                                        <label>
                                            <%#Eval("BankName")%></label>
                                    </div>
                                    <div style="clear: both;">
                                        <label>
                                            Account Holder:</label>
                                        <label>
                                            <%#Eval("AccountHolder")%></label>
                                    </div>
                                    <div style="clear: both;">
                                        <label>
                                            Account Type:</label>
                                        <label>
                                            <%#Eval("AccountType")%></label>
                                    </div>
                                    <div style="clear: both;">
                                        <label>
                                            Account No:</label>
                                        <label>
                                            <%#Eval("AccountNo")%></label>
                                    </div>
                                    <div style="clear: both;">
                                        <label>
                                            Branch:</label>
                                        <label>
                                            <%#Eval("Branch")%></label>
                                    </div>
                                    <div style="clear: both;">
                                        <label>
                                            IFSC Code:</label>
                                        <label>
                                            <%#Eval("IFSCCode")%></label>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr runat="server" id="paypal">
                    <td>
                        <div class="col">
                            <h3>
                                <a href="#">Donate By Paypal</a></h3>
                        </div>
                    </td>
                </tr>
                <tr runat="server" id="paypaldetail">
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="margin: 10px 60px 10px 60px"
                            width="100%">
                            <tr style="height: 35px;">
                                <td style="width: 80px;">
                                    <label>
                                        Name :</label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtName" ValidationGroup="donate" Width="270" Height="23"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtName" ValidationGroup="donate"
                                        ID="RequiredFieldValidator1" ForeColor="Red" Display="Dynamic" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td style="width: 80px;">
                                    <label>
                                        Amount :</label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtAmmount" Width="240" ValidationGroup="donate"
                                        Height="23"></asp:TextBox><label>&nbsp;USD</label>
                                    <asp:RequiredFieldValidator ControlToValidate="txtAmmount" ValidationGroup="donate"
                                        ID="RequiredFieldValidator2" ForeColor="Red" Display="Dynamic" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ValidationGroup="donate"
                                        Display="Dynamic" ControlToValidate="txtAmmount" Operator="DataTypeCheck" runat="server"
                                        Type="Integer" ErrorMessage="Ammount must be interger only."></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr style="height: 70px;">
                                <td style="width: 80px; vertical-align: top;">
                                    <label>
                                        Purpose :</label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPurpose" TextMode="MultiLine" ValidationGroup="donate"
                                        Width="272" Height="53"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtPurpose" ValidationGroup="donate"
                                        ID="RequiredFieldValidator3" ForeColor="Red" Display="Dynamic" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td style="width: 80px;">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="btnPaypal" ValidationGroup="donate" ImageUrl="design/btn_donateCC_LG.gif"
                                        OnClick="btnPaypal_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="cols5-bottom">
    </div>
    <hr class="noscreen" />
</asp:Content>
