<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="SiteMap.aspx.cs" Inherits="Modikhana.SiteMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        a
        {
            text-decoration: none;
            color: Gray;
        }
        .tdwidth
        {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <div style="float: left;">
            <table style="margin: 15px;">
                <tr>
                    <td>
                        <h2>
                            Site Map !
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
                        <table cellpadding="0" style="margin-left: 60px;" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <h3>
                                        Root</h3>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td class="tdwidth">
                                    <a href="Default.aspx">Home</a>
                                </td>
                                <td class="tdwidth">
                                    <a href="MemberLogin.aspx">Login</a>
                                </td>
                                <td class="tdwidth">
                                    <a href="MemberRegistration.aspx">Register</a>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td class="tdwidth">
                                    <a href="Feedback.aspx">Feedback</a>
                                </td>
                                <td class="tdwidth">
                                    <a href="SiteMap.aspx">Site Map</a>
                                </td>
                                <td class="tdwidth">
                                    <a href="OurWork.aspx">Our Work</a>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td class="tdwidth">
                                    <a href="NewsRoom.aspx">News Room</a>
                                </td>
                                <td class="tdwidth">
                                    <a href="Event.aspx">Events</a>
                                </td>
                                <td class="tdwidth">
                                    <a href="OurHelp.aspx">Social Help</a>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td class="tdwidth">
                                    <a href="Post.aspx">Post Topic</a>
                                </td>
                                <td class="tdwidth">
                                    <a href="Donation.aspx">Donation</a>
                                </td>
                                <td class="tdwidth">
                                    <a href="AboutUs.aspx">About Us</a>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td class="tdwidth">
                                    <a href="ContactUs.aspx">Contact Us</a>
                                </td>
                                <td class="tdwidth">
                                    &nbsp;
                                </td>
                                <td class="tdwidth">
                                    &nbsp;
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
