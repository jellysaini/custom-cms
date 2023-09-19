<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="ContactUs.aspx.cs" Inherits="Modikhana.ContactUs" %>

<%@ Register Src="WebUserControl/ContactDetail.ascx" TagName="ContactDetail" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr class="noscreen" />
    <div class="divleftright">
        <div class="divleft">
            <div id="cols6-top">
            </div>
            <div id="cols6" class="box">
                <table border="0" style="margin-left: 15px;" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td colspan="2">
                            <h2>
                                Contact Us</h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 290px;">
                            <table>
                                <tr>
                                    <td>
                                        <img src="design/ContactUs.jpg" alt="" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="vertical-align: top;">
                            <table>
                                <tr>
                                    <td>
                                        Name
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="contactus"
                                            ID="txtUserName"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="contactus"
                                            ControlToValidate="txtUserName" ForeColor="Red" Display="Static" runat="server"
                                            ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="contactus"
                                            ID="txtEmailAddress"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="contactus"
                                            ControlToValidate="txtEmailAddress" ForeColor="Red" Display="Static" runat="server"
                                            ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="txtEmailAddress" ForeColor="Red"
                                            ValidationGroup="contactus" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invaild email Address."></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Message
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="txtAddWidthHeight" ValidationGroup="contactus"
                                            ID="txtMessage" TextMode="MultiLine"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="contactus"
                                            ControlToValidate="txtMessage" ForeColor="Red" Display="Static" runat="server"
                                            ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: bottom;">
                                        <asp:Button runat="server" ValidationGroup="contactus" SkinID="NormalButton" Text="Send"
                                            ID="btnSend" OnClick="btnSend_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button runat="server" CausesValidation="false" Text="Clear" ID="btnClear" SkinID="NormalButton"
                                            OnClick="btnClear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label Style="margin-left: 300px;" runat="server" ID="msg" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- /cols2 -->
            <div id="cols6-bottom">
            </div>
        </div>
        <div class="divright">
            <div id="cols7-top">
            </div>
            <div id="cols7" class="box">
                <uc1:ContactDetail ID="ContactDetail1" runat="server" />
            </div>
            <!-- /cols2 -->
            <div id="cols7-bottom">
            </div>
        </div>
    </div>
    <hr class="noscreen" />
</asp:Content>
