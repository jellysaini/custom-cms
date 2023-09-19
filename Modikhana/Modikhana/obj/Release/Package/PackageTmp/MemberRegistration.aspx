<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="MemberRegistration.aspx.cs" Inherits="Modikhana.MemberRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/NewsScroll/style.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/NewsScroll/jquery-latest.pack.js" type="text/javascript"></script>
    <script src="Scripts/NewsScroll/jcarousellite_1.0.1c4.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".newsticker-jcarousellite").jCarouselLite({
                vertical: true,
                visible: 6,
                auto: 500,
                speed: 2000,
                hoverPause: true,
                btnNext: ".next",
                btnPrev: ".prev"
            });
        }); 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="cols2-top">
    </div>
    <div id="cols2" class="box">
        <!-- Blog -->
        <div id="col-left">
            <table border="0" style="margin-left: 15px;" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <h2>
                            Create an account</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            All fields are mandatory.
                        </label>
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
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        ID="txtFirstName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="register"
                                        ControlToValidate="txtFirstName" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    Last Name :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        ID="txtLastName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="register"
                                        ControlToValidate="txtLastName" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    Email Address :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        ID="txtEmail"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="register"
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
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        ID="txtLoginName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="register"
                                        ControlToValidate="txtLoginName" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CausesValidation="false" Text="check availability !"
                                        Style="text-decoration: none; color: Maroon;" ID="lnkalreadyexist" OnClick="lnkalreadyexist_Click"></asp:LinkButton><br />
                                    <asp:Label runat="server" ID="lblalreadyexist" Style="display: none;" Height="30"
                                        Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    Choose a password :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        TextMode="Password" ID="txtPassword"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="register"
                                        ControlToValidate="txtPassword" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    Re-enter password :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        TextMode="Password" ID="txtReenterPassword"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="register"
                                        ControlToValidate="txtReenterPassword" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtReenterPassword"
                                        ControlToCompare="txtPassword" ForeColor="Red" ValidationGroup="register" Display="Dynamic"
                                        runat="server" ErrorMessage="Passwords do not match. "></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr style="height: 55px;">
                                <td style="vertical-align: top;">
                                    Address :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        TextMode="MultiLine" Height="40" ID="txtAddress"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="register"
                                        Style="vertical-align: top;" ControlToValidate="txtAddress" ForeColor="Red" Display="Static"
                                        runat="server" ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    Mobile No :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        ID="txtMobile"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="register"
                                        ControlToValidate="txtMobile" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    Phone No :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        ID="txtPhone"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="register"
                                        ControlToValidate="txtPhone" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    Country :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        ID="txtCountry"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="register"
                                        ControlToValidate="txtCountry" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 35px;">
                                <td>
                                    State :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        ID="txtState"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="register"
                                        ControlToValidate="txtState" ForeColor="Red" Display="Static" runat="server"
                                        ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 40px;">
                                <td>
                                    City :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="register"
                                        ID="txtCity"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="register"
                                        ControlToValidate="txtCity" ForeColor="Red" Display="Static" runat="server" ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="vertical-align: bottom;">
                                    <asp:Button runat="server" ValidationGroup="register" SkinID="NormalButton" Text="Save"
                                        ID="btnSend" OnClick="btnSend_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button runat="server" CausesValidation="false" Text="Clear" ID="btnClear" SkinID="NormalButton"
                                        Height="28" OnClick="btnClear_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblMsg" Height="30" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <!-- /col-left -->
        <hr class="noscreen" />
        <!-- Testimonials -->
        <div id="col-right">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <h2>
                            Latest News</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="newsticker-demo">
                            <div class="newsticker-jcarousellite">
                                <ul>
                                    <asp:Repeater runat="server" ID="RepeaterNews">
                                        <ItemTemplate>
                                            <li>
                                                <div class="thumbnail">
                                                    <img src='<%# "Handler/Thumbnail100x75.ashx?ImURL="+Eval("NewsImagePath") %>' alt="">
                                                </div>
                                                <div class="info">
                                                    <a style="text-decoration: none;" href="NewsRoomDetail.aspx?News=<%#Eval("ID")%>">
                                                        <%# Eval("NewsName") %>
                                                    </a>
                                                </div>
                                                <div class="clear">
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <!-- /col-right -->
    </div>
    <div id="cols2-bottom">
    </div>
</asp:Content>
