<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="DonationFail.aspx.cs" Inherits="Modikhana.DonationFail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="cols6-top" style="margin-left: auto; margin-right: auto;">
        </div>
        <div id="cols6" style="margin-left: auto; margin-right: auto;">
            <table border="0" style="margin-left: 15px;" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: middle;">
                        <h1 style="font-size: 43px; font-weight: bold;">
                            Sorry, Your donation has<br />
                            been failed.
                        </h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div id="cols6-bottom" style="margin-left: auto; margin-right: auto;">
        </div>
    </div>
    <script type="text/javascript">
        $("#Donation").addClass("tray-active");
    </script>
</asp:Content>
