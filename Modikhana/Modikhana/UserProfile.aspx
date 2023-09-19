<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="UserProfile.aspx.cs" Inherits="Modikhana.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <table border="0" style="margin-left: 50px;" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <h2>
                        Update user profile</h2>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr style="height: 35px;">
                            <td>
                                Fist Name :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    ID="txtFirstName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="userprofile"
                                    ControlToValidate="txtFirstName" ForeColor="Red" Display="Static" runat="server"
                                    ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 35px;">
                            <td>
                                Last Name :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    ID="txtLastName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="userprofile"
                                    ControlToValidate="txtLastName" ForeColor="Red" Display="Static" runat="server"
                                    ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 35px;">
                            <td>
                                Email Address :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    ID="txtEmail"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="userprofile"
                                    ControlToValidate="txtEmail" ForeColor="Red" Display="Static" runat="server"
                                    ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="register"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                                    ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invaild email Address."></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr style="height: 35px;">
                            <td>
                                Desired Login Name :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    Enabled="false" ID="txtLoginName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="userprofile"
                                    ControlToValidate="txtLoginName" ForeColor="Red" Display="Static" runat="server"
                                    ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 55px;">
                            <td style="vertical-align: top;">
                                Address :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    TextMode="MultiLine" Height="40" ID="txtAddress"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="userprofile"
                                    ControlToValidate="txtAddress" ForeColor="Red" Display="Static" runat="server"
                                    ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 35px;">
                            <td>
                                Mobile No :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    ID="txtMobile"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="userprofile"
                                    ControlToValidate="txtMobile" ForeColor="Red" Display="Static" runat="server"
                                    ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 35px;">
                            <td>
                                Phone No :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    ID="txtPhone"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="userprofile"
                                    ControlToValidate="txtPhone" ForeColor="Red" Display="Static" runat="server"
                                    ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 35px;">
                            <td>
                                Country :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    ID="txtCountry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="userprofile"
                                    ControlToValidate="txtCountry" ForeColor="Red" Display="Static" runat="server"
                                    ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 35px;">
                            <td>
                                State :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    ID="txtState"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="userprofile"
                                    ControlToValidate="txtState" ForeColor="Red" Display="Static" runat="server"
                                    ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 40px;">
                            <td>
                                City :
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="userprofile"
                                    ID="txtCity"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="userprofile"
                                    ControlToValidate="txtCity" ForeColor="Red" Display="Static" runat="server" ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td style="vertical-align: bottom;">
                                <asp:Button runat="server" ValidationGroup="userprofile" SkinID="NormalButton" Text="Update"
                                    ID="btnSend" OnClick="btnSend_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Style="margin-left: 240px;" runat="server" ID="lblMsg" Height="30" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="cols5-bottom">
    </div>
    <hr class="noscreen" />
    <script type="text/javascript">
        $("#Home").addClass("tray-active");
        $("#lnkProfile").addClass("nav-active");
    </script>
</asp:Content>
