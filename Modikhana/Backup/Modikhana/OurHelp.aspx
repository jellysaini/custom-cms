<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="OurHelp.aspx.cs" Inherits="Modikhana.OurHelp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Modikhana.BAL.ContentManagement objPage = new Modikhana.BAL.ContentManagement();
        Modikhana.DAL.tblContentManagement PageData = new Modikhana.DAL.tblContentManagement();
        PageData = objPage.SelectByPageId(1);
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
                        <td>
                            &nbsp;
                        </td>
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
        <div style="float: right; margin-right: 30px; width: 270px">
            <img src="design/HelpingHand.jpg" alt="" />
        </div>
        <div style="clear: both;">
            <table style="margin-left: 15px;">
                <tr>
                    <td>
                        <h4>
                            If you need any kind of help please write to us.One of our member will contact you
                            soon.
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtOurHelp" ValidationGroup="ourhelp"
                            Width="650" Height="180"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ourhelp"
                            ControlToValidate="txtOurHelp" ForeColor="Red" Display="Dynamic" runat="server"
                            ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="erroMsg" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;">
                        <asp:Button runat="server" ValidationGroup="ourhelp" SkinID="NormalButton" Text="Send"
                            ID="btnSend" onclick="btnSend_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" CausesValidation="false" Text="Clear" ID="btnClear" 
                            SkinID="NormalButton" onclick="btnClear_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="cols5-bottom">
    </div>
    <hr class="noscreen" />
</asp:Content>
