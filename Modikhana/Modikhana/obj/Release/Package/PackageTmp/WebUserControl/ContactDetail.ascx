<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactDetail.ascx.cs"
    Inherits="Modikhana.WebUserControl.ContactDetail" %>
<asp:Repeater runat="server" ID="contactDetailRepeater">
    <HeaderTemplate>
        <table border="0" style="margin-left: 15px;" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <h2>
                        Contact Details</h2>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <h3>
                    <%#Eval("OfficeLocation")%></h3>
            </td>
        </tr>
        <tr>
            <td>
                <ul>
                    <li>
                        <label>
                            Address :</label>
                        <%#Eval("Address")%></li>
                    <li>
                        <label>
                            City :</label>
                        <%#Eval("City")%></li>
                    <li>
                        <label>
                            State :</label>
                        <%#Eval("State")%></li>
                    <li>
                        <label>
                            Telephone :</label>
                        <%#Eval("Telephone")%></li>
                    <li>
                        <label>
                            Mobile :</label>
                        <%#Eval("Mobile")%></li>
                    <li>
                        <label>
                            Email :</label><%#Eval("Email")%></li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
